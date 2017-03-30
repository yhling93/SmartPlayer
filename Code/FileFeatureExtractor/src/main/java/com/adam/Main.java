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

        String rootdir = "/home/adam/Experiment_Data/20170319/Interaction_Data/";
        File[] files = new File(rootdir).listFiles();

        int totalCnt = 0;

        for(File file : files) {
            System.out.println(file.getAbsolutePath());
            String sessionFilePath = file.getAbsolutePath() + "/session";
            String momentFilePath = file.getAbsolutePath() + "/moment";
            String periodFilePath = file.getAbsolutePath() + "/period";
            String featureFilePath = file.getAbsolutePath() + "/feature_interaction";
            File sessionFile = new File(sessionFilePath);
            File periodFile = new File(periodFilePath);
            File momentFile = new File(momentFilePath);
            File featureFile = new File(featureFilePath);
            try {
                featureFile.createNewFile();
            } catch (IOException e) {
                e.printStackTrace();
            }
            FeatureExtractor fx = new FeatureExtractor(sessionFile, momentFile, periodFile, featureFile);
            System.out.println("Start handling session " + fx.session.SessionID);
            fx.readMomentEvent();
            fx.readPeriodEvent();
            fx.printFeature();
            System.out.println("End handling session " + fx.session.SessionID);
            totalCnt++;
        }

        System.out.println("Total files generated: " + totalCnt);

//        String sessionFilePath = rootdir + "/session";
//        String momentFilePath = rootdir + "/moment";
//        String periodFilePath = rootdir + "/period";
//
//        File sessionFile = new File(sessionFilePath);
//        File periodFile = new File(periodFilePath);
//        File momentFile = new File(momentFilePath);
//
//        File featureFile = new File(rootdir +  File.separator + "feature3");
//        try {
//            featureFile.createNewFile();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }



    }
}
