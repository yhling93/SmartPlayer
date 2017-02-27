package com.adam;

/**
 * Created by adam on 17-2-23.
 */
public class InteractionFeature {

    // 1 for true, 0 for false
    public int play;
    public int pause;
    public int fastForward;
    public int rewind;
    public int forwardSkip;
    public int reverseSkip;
    public int fullScreen;

    public int playTime = 1;
    public double rate;

    public static InteractionFeature createFeature(InteractionFeature lastFeature) {
        InteractionFeature feature = new InteractionFeature();
        feature.playTime = lastFeature.playTime;
        feature.pause = lastFeature.pause;
        feature.play = lastFeature.play;
        feature.fastForward = lastFeature.fastForward;
        feature.rewind = lastFeature.rewind;
        feature.forwardSkip = lastFeature.forwardSkip;
        feature.reverseSkip = lastFeature.reverseSkip;
        feature.fullScreen = lastFeature.fullScreen;
        feature.rate = lastFeature.rate;
        return feature;
    }

}
