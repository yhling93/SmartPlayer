package com.adam;

import com.adam.Data.MomentEvent;
import com.adam.Data.PeriodEvent;
import com.adam.Data.Session;
import com.google.gson.Gson;

import java.io.*;
import java.util.LinkedList;
import java.util.Queue;

/**
 * Created by adam on 17-2-24.
 */
public class FeatureExtractor {

    private Session session;
    private InteractionFeature feature;

    private FileReader sessionFr = null;
    private BufferedReader sessionBr = null;
    private FileReader momentFr = null;
    private BufferedReader momentBr = null;
    private FileReader periodFr = null;
    private BufferedReader periodBr = null;

    private Gson gson;


    public FeatureExtractor(File sessionFile, File momentFile, File periodFile) {
        initFeature();
        gson = new Gson();

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
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                sessionBr.close();
                sessionFr.close();
                sessionBr = null;
                sessionFr = null;
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    public void startExtraction() {

        String momentStr, periodStr;
        long length = session.EndTime - session.StartTime;

        try {
            String lastMomentStr = momentBr.readLine();
            String lastPeriodStr = periodBr.readLine();

            MomentEvent lastMomentEvent = lastMomentStr == null ? null : gson.fromJson(lastMomentStr, MomentEvent.class);
            PeriodEvent lastPeriodEvent = lastPeriodStr == null ? null : gson.fromJson(lastPeriodStr, PeriodEvent.class);

            long curTime = session.StartTime;

            Queue<MomentEvent> lastMomentQueue = new LinkedList<MomentEvent>();
            Queue<PeriodEvent> lastPeriodEvents = new LinkedList<PeriodEvent>();

            while(curTime != session.EndTime) {

                while(lastMomentEvent != null && lastMomentEvent.HappenTS.absTS == curTime) {
                    //handleMomentEvent(lastMomentEvent);
                    lastMomentStr = momentBr.readLine();
                    lastMomentEvent = lastMomentStr == null ? null : gson.fromJson(lastMomentStr, MomentEvent.class);
                }
                while(lastPeriodEvent != null && lastPeriodEvent.StartTS.absTS == curTime) {
                    handlePeriodEvent(lastPeriodEvent);
                    System.out.println(curTime + " " + gson.toJson(feature));

                    if(lastPeriodEvent != null && lastPeriodEvent.EndTS.absTS == curTime) {
                        resetPeriodFeatures();
                        lastPeriodStr = periodBr.readLine();
                        lastPeriodEvent = lastPeriodStr == null ? null : gson.fromJson(lastPeriodStr, PeriodEvent.class);
                    } else {
                        break;
                    }
                }

                curTime++;
            }

            // genearte feature for every second
//            for(long i = 0; i < length; i++) {
//
//                long now = i + session.StartTime;
//
//                // handle moment event
//                if(lastMomentEvent != null && lastMomentEvent.HappenTS.absTS == now) {
//                    handleMomentEvent(lastMomentEvent);
//                    lastMomentStr = momentBr.readLine();
//                    lastMomentEvent = lastMomentStr == null ? null : gson.fromJson(lastMomentStr, MomentEvent.class);
//                } else if(lastMomentEvent != null && lastMomentEvent.HappenTS.absTS == now-1) {
//
//                }
//
//
//                // handle period event
//                if(lastPeriodEvent != null && lastPeriodEvent.StartTS.absTS == now ) {
//                    handlePeriodEvent(lastPeriodEvent);
//                }
//                System.out.println(now + " " + gson.toJson(feature));
//
//                if(lastPeriodEvent != null && lastPeriodEvent.EndTS.absTS == now) {
//                    // period event end
//                    // reset params
//                    resetPeriodFeatures();
//                    lastPeriodStr = periodBr.readLine();
//                    lastPeriodEvent = lastPeriodStr == null ? null : gson.fromJson(lastPeriodStr, PeriodEvent.class);
//                }
//
//
//            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void initFeature() {
        feature = new InteractionFeature();
        feature.play = 0;
        feature.pause = 0;
        feature.fastForward = 0;
        feature.rewind = 0;
        feature.forwardSkip = 0;
        feature.reverseSkip = 0;
        feature.fullScreen = 0;
        feature.playTime = 1;
        feature.rate = 1.0f;
    }

    private void handleMomentEvent(MomentEvent event) {
        switch (event.Type) {
            case 10:
                // play
                feature.play = 1;
                feature.pause = 0;
                break;
            case 11:
                // pause
                feature.play = 0;
                feature.pause = 1;
                break;
            case 12:
                // stop
                break;
            case 13:
                // enter full screen
                feature.fullScreen = 1;
                break;
            case 14:
                // exit full screen
                feature.fullScreen = 0;
                break;
            case 15:
                // change play rate
                feature.rate = event.PlayRate;
                break;
        }
    }

    private void handlePeriodEvent(PeriodEvent event) {
        switch (event.Type) {
            case 20:
                // fast forward
                feature.fastForward = 1;
                break;
            case 21:
                // rewind
                feature.rewind = 1;
                break;
            case 22:
                // forward skip
                feature.forwardSkip = 1;
                break;
            case 23:
                // reverse skip
                feature.reverseSkip = 1;
                break;
        }
    }

    private void resetPeriodFeatures() {
        feature.fastForward = 0;
        feature.rewind = 0;
        feature.forwardSkip = 0;
        feature.reverseSkip = 0;
    }

}
