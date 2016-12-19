using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using SmartPlayer.DB;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data.RealSenseData;

namespace SmartPlayer.RealSense
{
    class TrackModule
    {

        private DBHelper dbhelper;
        /// <summary>
        /// 窗体，用来令此窗口更新
        /// </summary>
        private readonly MainForm m_form;

        private const int NUM_PERSONS = 1;

        /// <summary>
        /// 构造函数，将窗体传进来
        /// </summary>
        /// <param name="form"></param>
        public TrackModule(MainForm form)
        {
            m_form = form;
            dbhelper = new DBHelper();
            //InteractionEvent ievent = new InteractionEvent();
            //ievent.eventType = EventType.PauseEvent;
            //ievent.eventParams = new Dictionary<string, string>();
            //ievent.eventParams.Add("key", "value");
            //ievent.happenTS = new Data.CustomTime();
            //ievent.happenTS.absTS = DateTime.Now;
            //ievent.happenTS.videoTS = 70;
            //dbhelper.saveEntity(ievent);
        }

        /// <summary>
        /// 简易版本的流程，将color图像流置于picturebox中
        /// 后续将修改为带有面部和手部的流
        /// </summary>
        public void NaivePipeline()
        {
            PXCMSenseManager pp = m_form.Session.CreateSenseManager();

            if (pp == null)
            {
                throw new Exception("PXCMSenseManager null");
            }

            pp.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 1920, 1080);

            pp.Init();

            while (!m_form.Stopped)
            {
                if (pp.AcquireFrame(true).IsError()) break;

                var isConnected = pp.IsConnected();
                if (isConnected)
                {
                    var sample = pp.QuerySample();
                    if (sample == null)
                    {
                        pp.ReleaseFrame();
                        continue;
                    }

                    // default is COLOR
                    DisplayPicture(sample.color);
                    m_form.UpdatePic();

                }
                pp.ReleaseFrame();
            }

            pp.Close();
            pp.Dispose();
        }

        /// <summary>
        /// 面部
        /// </summary>
        public void FacePipeLine()
        {
            PXCMSenseManager pp = m_form.Session.CreateSenseManager();

            if (pp == null)
            {
                throw new Exception("PXCMSenseManager null");
            }

            pp.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 1920, 1080);

            // 面部初始化
            pp.EnableFace();
            PXCMFaceModule faceModule = pp.QueryFace();
            if(faceModule==null)
            {
                Debug.Assert(true);
                return;
            }
            PXCMFaceConfiguration faceCfg = faceModule.CreateActiveConfiguration();
            if(faceCfg==null)
            {
                Debug.Assert(true);
                return;
            }
            faceCfg.SetTrackingMode(PXCMFaceConfiguration.TrackingModeType.FACE_MODE_COLOR_PLUS_DEPTH);
            faceCfg.strategy = PXCMFaceConfiguration.TrackingStrategyType.STRATEGY_CLOSEST_TO_FARTHEST;
            // 单个人追踪
            faceCfg.detection.maxTrackedFaces = NUM_PERSONS;
            faceCfg.landmarks.maxTrackedFaces = NUM_PERSONS;
            faceCfg.pose.maxTrackedFaces = NUM_PERSONS;

            // 表情初始化
            PXCMFaceConfiguration.ExpressionsConfiguration expressionCfg = faceCfg.QueryExpressions();
            if (expressionCfg == null)
            {
                throw new Exception("ExpressionsConfiguration null");
            }
            expressionCfg.properties.maxTrackedFaces = NUM_PERSONS;

            expressionCfg.EnableAllExpressions();
            faceCfg.detection.isEnabled = true;
            faceCfg.landmarks.isEnabled = true;
            faceCfg.pose.isEnabled = true;
            if (expressionCfg!= null)
            {
                expressionCfg.Enable();
            }

            //脉搏初始化
            PXCMFaceConfiguration.PulseConfiguration pulseConfiguration = faceCfg.QueryPulse();
            if (pulseConfiguration == null)
            {
                throw new Exception("pulseConfiguration null");
            }

            pulseConfiguration.properties.maxTrackedFaces = NUM_PERSONS;
            if (pulseConfiguration != null)
            {
                pulseConfiguration.Enable();
            }

            // 面部识别功能初始化
            //PXCMFaceConfiguration.RecognitionConfiguration qrecognition = faceCfg.QueryRecognition();
            //if (qrecognition == null)
            //{
            //    throw new Exception("PXCMFaceConfiguration.RecognitionConfiguration null");
            //}
            //else
            //{
            //    qrecognition.Enable();
            //}

            faceCfg.ApplyChanges();
            
            if(pp.Init()<pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                throw new Exception("Init failed");
            }
            else
            {
                using (PXCMFaceData faceData = faceModule.CreateOutput())
                {
                    if(faceData==null)
                    {
                        throw new Exception("face data failure");
                    }
                    while (!m_form.Stopped)
                    {
                        if (pp.AcquireFrame(true).IsError()) break;

                        var isConnected = pp.IsConnected();
                        if (isConnected)
                        {
                            var sample = pp.QueryFaceSample();
                            if (sample == null)
                            {
                                pp.ReleaseFrame();
                                continue;
                            }

                            // default is COLOR
                            DisplayPicture(sample.color);

                            // 如果检测脸数==0，则continue
                            faceData.Update();
                            int nFace = faceData.QueryNumberOfDetectedFaces();
                            if(nFace==0)
                            {
                                continue;
                            }

                            // 存
                            PXCMFaceData.Face face = faceData.QueryFaceByIndex(0);
                            //SaveFaceLandmarkData(face);
                            //SaveFacialExpressionData(face);

                            m_form.UpdatePic();

                        }
                        pp.ReleaseFrame();
                    }
                }
            }

           

            pp.Close();
            pp.Dispose();
        }

        public static pxcmStatus OnNewFrame(Int32 mid, PXCMBase module, PXCMCapture.Sample sample)
        {
            return pxcmStatus.PXCM_STATUS_NO_ERROR;
        }

        public void HandPipeLine()
        {
            PXCMSenseManager pp = m_form.Session.CreateSenseManager();

            if (pp == null)
            {
                throw new Exception("PXCMSenseManager null");
            }

            pp.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 1920, 1080);

            //手 初始化
            PXCMHandModule handAnalysis;
            PXCMSenseManager.Handler handler = new PXCMSenseManager.Handler();
            handler.onModuleProcessedFrame = new PXCMSenseManager.Handler.OnModuleProcessedFrameDelegate(OnNewFrame);
            PXCMHandConfiguration handConfiguration = null;
            PXCMHandData handData = null;


            pxcmStatus status = pp.EnableHand();
            handAnalysis = pp.QueryHand();

            if (status != pxcmStatus.PXCM_STATUS_NO_ERROR || handAnalysis == null)
            {

                Console.WriteLine("hand module load failed");
                return;
            }
            handConfiguration = handAnalysis.CreateActiveConfiguration();
            if (handConfiguration == null)
            {
                Console.WriteLine("Failed Create Configuration");
                return;
            }
            handData = handAnalysis.CreateOutput();
            if (handData == null)
            {
                Console.WriteLine("Failed Create Output");
                return;
            }

            if(pp.Init(handler)!=pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                Console.WriteLine("init failed");
                return;
            }

            if (handConfiguration != null)
            {
                PXCMHandData.TrackingModeType trackingMode = PXCMHandData.TrackingModeType.TRACKING_MODE_FULL_HAND;

                // 配置收的Tracking Mode
                trackingMode = PXCMHandData.TrackingModeType.TRACKING_MODE_FULL_HAND;

                handConfiguration.SetTrackingMode(trackingMode);

                handConfiguration.EnableAllAlerts();
                handConfiguration.EnableSegmentationImage(true);
                bool isEnabled = handConfiguration.IsSegmentationImageEnabled();

                handConfiguration.ApplyChanges();

                int totalNumOfGestures = handConfiguration.QueryGesturesTotalNumber();

                if (totalNumOfGestures > 0)
                {
                    for (int i = 0; i < totalNumOfGestures; i++)
                    {
                        string gestureName = string.Empty;
                        if (handConfiguration.QueryGestureNameByIndex(i, out gestureName) ==
                            pxcmStatus.PXCM_STATUS_NO_ERROR)
                        {
                            Console.WriteLine(gestureName);
                        }
                    }
                }
            }


            int frameCounter = 0;
            int frameNumber = 0;

            while (!m_form.Stopped)
            {
                string gestureName = "fist";
                if (handConfiguration != null)
                {
                    if (string.IsNullOrEmpty(gestureName) == false)
                    {
                        if (handConfiguration.IsGestureEnabled(gestureName) == false)
                        {
                            handConfiguration.DisableAllGestures();
                            handConfiguration.EnableGesture(gestureName, true);
                            handConfiguration.ApplyChanges();
                        }
                    }
                    else
                    {
                        handConfiguration.DisableAllGestures();
                        handConfiguration.ApplyChanges();
                    }
                }

                if (pp.AcquireFrame(true) < pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    break;
                }

                frameCounter++;

                if (pp.IsConnected())
                {
                    PXCMCapture.Sample sample;
                    sample = pp.QueryHandSample();
                    if (sample != null && sample.depth != null)
                    {
                        // frameNumber = liveCamera ? frameCounter : instance.captureManager.QueryFrameIndex();
                        frameNumber = frameCounter;
                    }
                    //bool b=(sample.ir==null);
                    //b = (sample.color== null);
                    //b = (sample.left == null);
                    //b = (sample.right == null);
                    DisplayPicture(sample.depth);

                    if (handData != null)
                    {
                        handData.Update();

                        SaveHandData(handData);
                    }
                    m_form.UpdatePic();
                }
                pp.ReleaseFrame();


            }

            if (handData != null) handData.Dispose();
            if (handConfiguration != null) handConfiguration.Dispose();

            pp.Close();
            pp.Dispose();
        }
        public void FaceAndHandPipeLine()
        {
            PXCMSenseManager pp = m_form.Session.CreateSenseManager();

            if (pp == null)
            {
                throw new Exception("PXCMSenseManager null");
            }

            pp.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 1920, 1080);

            // 面部初始化
            pp.EnableFace();
            PXCMFaceModule faceModule = pp.QueryFace();
            if (faceModule == null)
            {
                Debug.Assert(true);
                return;
            }
            PXCMFaceConfiguration faceCfg = faceModule.CreateActiveConfiguration();
            if (faceCfg == null)
            {
                Debug.Assert(true);
                return;
            }
            faceCfg.SetTrackingMode(PXCMFaceConfiguration.TrackingModeType.FACE_MODE_COLOR_PLUS_DEPTH);
            faceCfg.strategy = PXCMFaceConfiguration.TrackingStrategyType.STRATEGY_CLOSEST_TO_FARTHEST;
            // 单个人追踪
            faceCfg.detection.maxTrackedFaces = NUM_PERSONS;
            faceCfg.landmarks.maxTrackedFaces = NUM_PERSONS;
            faceCfg.pose.maxTrackedFaces = NUM_PERSONS;

            // 表情初始化
            PXCMFaceConfiguration.ExpressionsConfiguration expressionCfg = faceCfg.QueryExpressions();
            if (expressionCfg == null)
            {
                throw new Exception("ExpressionsConfiguration null");
            }
            expressionCfg.properties.maxTrackedFaces = NUM_PERSONS;

            expressionCfg.EnableAllExpressions();
            faceCfg.detection.isEnabled = true;
            faceCfg.landmarks.isEnabled = true;
            faceCfg.pose.isEnabled = true;
            if (expressionCfg != null)
            {
                expressionCfg.Enable();
            }

            //脉搏初始化
            PXCMFaceConfiguration.PulseConfiguration pulseConfiguration = faceCfg.QueryPulse();
            if (pulseConfiguration == null)
            {
                throw new Exception("pulseConfiguration null");
            }

            pulseConfiguration.properties.maxTrackedFaces = NUM_PERSONS;
            if (pulseConfiguration != null)
            {
                pulseConfiguration.Enable();
            }

            faceCfg.ApplyChanges();

            if (pp.Init() < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                throw new Exception("Init failed");
            }
            else
            {
                using (PXCMFaceData faceData = faceModule.CreateOutput())
                {
                    if (faceData == null)
                    {
                        throw new Exception("face data failure");
                    }
                    while (!m_form.Stopped)
                    {
                        if (pp.AcquireFrame(true).IsError()) break;

                        var isConnected = pp.IsConnected();
                        if (isConnected)
                        {
                            var sample = pp.QueryFaceSample();
                            if (sample == null)
                            {
                                pp.ReleaseFrame();
                                continue;
                            }

                            // default is COLOR
                            DisplayPicture(sample.color);

                            // 如果检测脸数==0，则continue
                            faceData.Update();
                            int nFace = faceData.QueryNumberOfDetectedFaces();
                            if (nFace == 0)
                            {
                                continue;
                            }

                            // 存
                            PXCMFaceData.Face face = faceData.QueryFaceByIndex(0);
                            //SaveFaceLandmarkData(face);
                            SaveFacialExpressionData(face);

                            m_form.UpdatePic();

                        }
                        pp.ReleaseFrame();
                    }
                }
            }



            pp.Close();
            pp.Dispose();
        }

        private void SaveHandData(PXCMHandData handAnalysis)
        {
            int numOfHands = handAnalysis.QueryNumberOfHands();

            for (int j = 0; j < numOfHands; j++)
            {
                int id;
                PXCMImage.ImageData data;

                handAnalysis.QueryHandId(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, j, out id);
                //Get hand by time of appearance
                PXCMHandData.IHand handData;
                handAnalysis.QueryHandData(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, j, out handData);

                if (handData != null)
                {
                    HandData hd = new HandData();
                    hd.updateData(handData);

                    dbhelper.saveEntity(hd);
                }
            }
        }

        private void SaveFaceLandmarkData(PXCMFaceData.Face face)
        {
            FacialLandmarks flm = new FacialLandmarks();
            flm.updateData(face);
#if DEBUG
            //Console.WriteLine(flm.ToString());
#endif
            dbhelper.saveEntity(flm);           
        }

        private void SaveFacialExpressionData(PXCMFaceData.Face face)
        {
            FacialExpression fe = new FacialExpression();
            PXCMFaceData.ExpressionsData edata = face.QueryExpressions();
            if(edata==null)
            {
#if DEBUG
                Console.WriteLine("no expression this frame");
#endif
                return;
            }
#if DEBUG
            else
            {
                Console.WriteLine("catch expression");
            }
#endif
            for(int i=0;i<22;i++)
            {
                PXCMFaceData.ExpressionsData.FaceExpressionResult score;
                edata.QueryExpression((PXCMFaceData.ExpressionsData.FaceExpression)i, out score);
                fe.facialExpressionIndensity[i] = score.intensity;
            }
            //dbhelper.saveEntity(fe);
        }

        /// <summary>
        /// 将图像缓存入m_form中的m_bitmap中
        /// </summary>
        /// <param name="image"></param>
        private void DisplayPicture(PXCMImage image)
        {
            PXCMImage.ImageData data;
            if (image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_RGB32, out data) <
                pxcmStatus.PXCM_STATUS_NO_ERROR) return;
            m_form.DrawBitmap(data.ToBitmap(0, image.info.width, image.info.height));
            image.ReleaseAccess(data);
        }
    }
}