package com.adam;

import com.adam.Data.Session;
import com.google.gson.Gson;

import java.io.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
        int length = args.length;

//        String sessionFilePath = args[0];
//        String momentFilePath = args[1];
//        String periodFilePath = args[2];

        String sessionFilePath = "/home/adam/Downloads/session";
        String momentFilePath = "/home/adam/Downloads/moment";
        String periodFilePath = "/home/adam/Downloads/period";

        File sessionFile = new File(sessionFilePath);
        File momentFile = new File(momentFilePath);
        File periodFile = new File(periodFilePath);

        FeatureExtractor fx = new FeatureExtractor(sessionFile, momentFile, periodFile);
        fx.startExtraction();
    }
}
