package com.adam;

import com.adam.Data.Session;
import com.google.gson.Gson;

import java.io.*;
import java.util.concurrent.ThreadPoolExecutor;

public class Main {

    public static void main(String[] args) {
	// write your code here
        int length = args.length;

//        String sessionFilePath = args[0];
//        String momentFilePath = args[1];
//        String periodFilePath = args[2];

        String rootdir = "/home/adam/Experiment_Data/20170218/Interaction_Data/9";
        String sessionFilePath = rootdir + "/session";
        String momentFilePath = rootdir + "/moment";
        String periodFilePath = rootdir + "/period";

        File sessionFile = new File(sessionFilePath);
        File periodFile = new File(periodFilePath);
        File momentFile = new File(momentFilePath);

        File featureFile = new File(rootdir +  File.separator + "feature3");
        try {
            featureFile.createNewFile();
        } catch (IOException e) {
            e.printStackTrace();
        }

        FeatureExtractor fx = new FeatureExtractor(sessionFile, momentFile, periodFile, featureFile);
        fx.readMomentEvent();
        fx.readPeriodEvent();
        fx.printFeature();


//        String rootDir = "/home/adam/Experiment_Data/20170218/Interaction_Data";
//        File rootDirFile = new File(rootDir);
//
//        // 所有的数据文件夹
//        File[] layer1 = rootDirFile.listFiles();
//
//
//        for(File file : layer1) {
//            // 数据文件夹内的所有文件
//            // 共有3个文件：session，period，moment
//            String sessionFilePath = file.getAbsolutePath() + File.separator + "session";
//            String periodFilePath = file.getAbsolutePath() + File.separator + "period";
//            String momentFilePath = file.getAbsolutePath() + File.separator + "moment";
//
//            File sessionFile = new File(sessionFilePath);
//            File periodFile = new File(periodFilePath);
//            File momentFile = new File(momentFilePath);
//
//            File featureFile = new File(file.getAbsolutePath() + File.separator + "feature.txt");
//            try {
//                featureFile.createNewFile();
//            } catch (IOException e) {
//                e.printStackTrace();
//            }
//
//            FeatureExtractor fx = new FeatureExtractor(sessionFile, momentFile, periodFile, featureFile);
//            fx.readMomentEvent();
//            fx.readPeriodEvent();
//            fx.printFeature();
//        }
    }
}
