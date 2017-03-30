package com.adam;

import com.adam.Data.MomentEvent;
import com.adam.Data.PeriodEvent;
import com.adam.Data.Session;
import com.google.gson.Gson;

import java.io.*;
import java.util.*;

/**
 * Created by adam on 17-2-24.
 */
public class FeatureExtractor {

    public Session session;

    private FileReader sessionFr = null;
    private BufferedReader sessionBr = null;
    private FileReader momentFr = null;
    private BufferedReader momentBr = null;
    private FileReader periodFr = null;
    private BufferedReader periodBr = null;
    private File featureFile = null;
    private File sessionFile = null;
    private File periodFile = null;
    private File momentFile = null;

    private Gson gson;

    private static long threshold = 2;

    private InteractionFeature[] features;
    private int totalDuration;

    public FeatureExtractor(File sessionFile, File momentFile, File periodFile, File featureFile) {
        gson = new Gson();
        this.featureFile = featureFile;
        this.sessionFile = sessionFile;
        this.momentFile = momentFile;
        this.periodFile = periodFile;

        try {
            sessionFr = new FileReader(sessionFile);
            sessionBr = new BufferedReader(sessionFr);
            // skip the first line
            sessionBr.readLine();
            String str = sessionBr.readLine();
            session = gson.fromJson(str, Session.class);

            momentFr = new FileReader(momentFile);
            momentBr = new BufferedReader(momentFr);

            periodFr = new FileReader(periodFile);
            periodBr = new BufferedReader(periodFr);

            totalDuration = (int)(session.EndTime - session.StartTime);
            features = new InteractionFeature[totalDuration];

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if(sessionBr != null) {
                    sessionBr.close();
                }
                if(sessionFr != null) {
                    sessionFr.close();
                }
                sessionBr = null;
                sessionFr = null;
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * ！！！ 暂时不用该函数！！！
     * 功能：当一个事件的阈值秒之内发生了下一个事件且事件类型相同，将其合并为同一个事件
     */
    public void compressPeriodEvent() {
        try {
            String curPeriodStr = periodBr.readLine();
            PeriodEvent curPeriodEvent = curPeriodStr == null ? null : gson.fromJson(curPeriodStr, PeriodEvent.class);
            List<PeriodEvent> list = new ArrayList<PeriodEvent>();
            if(curPeriodEvent != null) {
                list.add(curPeriodEvent);
            }
            while((curPeriodStr = periodBr.readLine()) != null) {
                curPeriodEvent = gson.fromJson(curPeriodStr, PeriodEvent.class);

                PeriodEvent lastPeriodEvent = list.get(list.size()-1);
                // 如果当前发生事件距离上次发生事件时间小于阈值并且事件类型相同，则将他们合并成同一个事件
                if(curPeriodEvent.StartTS.absTS - lastPeriodEvent.EndTS.absTS <= threshold
                        && curPeriodEvent.Type == lastPeriodEvent.Type) {
                    lastPeriodEvent.EndTS.absTS = curPeriodEvent.EndTS.absTS;
                } else {
                    list.add(curPeriodEvent);
                }
            }

            for(int i = 0; i < list.size(); i++) {
                System.out.println(gson.toJson(list.get(i)));
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void readPeriodEvent() {
        try {
            String curPeriodStr;
            while ((curPeriodStr = periodBr.readLine()) != null) {
                // 读取当前事件
                PeriodEvent curPeriodEvent = gson.fromJson(curPeriodStr, PeriodEvent.class);
                // 事件持续时间
                int duration = (int)(curPeriodEvent.EndTS.absTS - curPeriodEvent.StartTS.absTS);
                // 相对偏移位置
                int idx = (int)(curPeriodEvent.StartTS.absTS - session.StartTime);
                // 将[idx+i ~ idx+duration]时间段内的feature全部设置为当前事件应该有的属性
                for(int i = 0; i <= duration; i++) {
                    if(features[idx + i] == null) {
                        features[idx + i] = new InteractionFeature();
                    }
                    // 处理事件
                    handlePeriodEvent(curPeriodEvent, features[idx + i]);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (periodBr != null) {
                    periodBr.close();
                }
                if (periodFr != null) {
                    periodFr.close();
                }
                periodBr = null;
                periodFr = null;
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    public void readMomentEvent() {
        try {
            // 根据定义：
            // 第一个时刻事件永远是播放开始
            // 最后一个时刻事件永远是播放停止

            // 处理第一个事件
            String curMomentStr = momentBr.readLine();
            MomentEvent curMomentEvent = gson.fromJson(curMomentStr, MomentEvent.class);
            if(features[0] == null) {
                features[0] = new InteractionFeature();
                features[0].rate = 1.0d;
            }
            handleMomentEvent(curMomentEvent, features[0]);

            // 查看下一个事件，下一个事件不可能为空，因为至少会停止播放
            String nextMomentStr = momentBr.readLine();
            MomentEvent nextMomentEvent = gson.fromJson(nextMomentStr, MomentEvent.class);
            int relativeHappenTS = (int) (nextMomentEvent.HappenTS.absTS - session.StartTime); // 事件发生时刻

            for(int i = 0; i < totalDuration; i++) {
                // 如果下一个事件发生时刻未到，则保持上一秒状态

                if(i != relativeHappenTS && i != 0) {
                    features[i] = InteractionFeature.createFeature(features[i - 1]);
                }

                // 如果下一个事件发生时刻到了，则读取所有这一秒发生的事件并处理
                while(i == relativeHappenTS && nextMomentEvent != null) {
                    // 如果此刻feature为空，先从上一秒复制一个feature（深拷贝）
                    if(features[i] == null) {
                        features[i] = InteractionFeature.createFeature(features[i-1]);
                    }
                    // 处理当前事件
                    handleMomentEvent(nextMomentEvent, features[i]);
                    // 读取下一个事件
                    nextMomentStr = momentBr.readLine();
                    nextMomentEvent = gson.fromJson(nextMomentStr, MomentEvent.class);
                    if(nextMomentStr != null && nextMomentEvent != null) {
                        relativeHappenTS = (int) (nextMomentEvent.HappenTS.absTS - session.StartTime);
                    } else {
                        // 这里的处理是因为有些moment file缺乏stop事件
                        // 下一个事件为空，则将下一个事件时间设置为结束时间（即停止）
                        nextMomentEvent = new MomentEvent();
                        nextMomentEvent.HappenTS.absTS = session.EndTime;
                        nextMomentEvent.Type = 12;
                        relativeHappenTS = (int) (nextMomentEvent.HappenTS.absTS - session.StartTime);
                    }

                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (momentBr != null) {
                    momentBr.close();
                }
                if (momentFr != null) {
                    momentFr.close();
                }
                momentBr = null;
                momentFr = null;
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    public void printFeature() {

        FileOutputStream fileOutputStream = null;
        BufferedOutputStream bufferedOutputStream = null;
        try {
            fileOutputStream = new FileOutputStream(featureFile);
            bufferedOutputStream = new BufferedOutputStream(fileOutputStream);
            String sessionInfo = "SessionID:\t" + session.SessionID + "\tStartTime:\t" + session.StartTime + "\tEndTime:\t" + session.EndTime + "\n";
            String firstLine = "play\t pause\t fastForward\t rewind\t forwardSkip\t reverseSkip\t fullScreen\t playTime\t rate\n";
            bufferedOutputStream.write(sessionInfo.getBytes());
            bufferedOutputStream.write(firstLine.getBytes());
            bufferedOutputStream.flush();
            StringBuilder sb;
            for(int i = 0; i < features.length; i++) {
                sb = new StringBuilder();
                sb.append(features[i].play + "\t");
                sb.append(features[i].pause + "\t");
                sb.append(features[i].fastForward + "\t");
                sb.append(features[i].rewind + "\t");
                sb.append(features[i].forwardSkip + "\t");
                sb.append(features[i].reverseSkip + "\t");
                sb.append(features[i].fullScreen + "\t");
                sb.append(features[i].playTime + "\t");
                sb.append(features[i].rate + "\n");
                bufferedOutputStream.write(sb.toString().getBytes());
                bufferedOutputStream.flush();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (bufferedOutputStream != null) {
                    bufferedOutputStream.flush();
                    bufferedOutputStream.close();
                }

                if (fileOutputStream != null) {
                    fileOutputStream.flush();
                    fileOutputStream.close();
                }
                bufferedOutputStream = null;
                fileOutputStream = null;
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    private void handleMomentEvent(MomentEvent event, InteractionFeature pfeature) {
        switch (event.Type) {
            case 10:
                // play
                pfeature.play = 1;
                pfeature.pause = 0;
                break;
            case 11:
                // pause
                pfeature.play = 0;
                pfeature.pause = 1;
                break;
            case 12:
                // stop
                break;
            case 13:
                // enter full screen
                pfeature.fullScreen = 1;
                break;
            case 14:
                // exit full screen
                pfeature.fullScreen = 0;
                break;
            case 15:
                // change play rate
                pfeature.rate = event.PlayRate;
                break;
        }
    }

    private void handlePeriodEvent(PeriodEvent event, InteractionFeature pfeature) {
        switch (event.Type) {
            case 20:
                // fast forward
                pfeature.fastForward = 1;
                break;
            case 21:
                // rewind
                pfeature.rewind = 1;
                break;
            case 22:
                // forward skip
                pfeature.forwardSkip = 1;
                break;
            case 23:
                // reverse skip
                pfeature.reverseSkip = 1;
                break;
        }
    }
}
