using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data.ContextData;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data.RealSenseData;
using System.Configuration;
using MongoDB.Driver;
using SmartPlayer.Data;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace SmartPlayer.DB
{
    public class DBHelper : IDB
    {

        IMongoClient mongoClient;
        IMongoDatabase mongoDatabase;

        public DBHelper()
        {
            string dbAddr = ConfigurationManager.AppSettings["MongoDB_Server"].ToString();
            string dbName = ConfigurationManager.AppSettings["MongoDB_DBName"].ToString();

            //mongoClient = new MongoClient(dbAddr);
            mongoClient = new MongoClient(dbAddr);
            mongoDatabase = mongoClient.GetDatabase(dbName);

            BsonSerializer.RegisterSerializer(new EnumSerializer<PXCMFaceData.LandmarksGroupType>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<PXCMFaceData.LandmarkType>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<EventType>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<PXCMHandData.GestureStateType>(BsonType.String));
        }

        public void saveEntity<T> (T obj)
        {
            string typeName = obj.GetType().Name;
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(typeName);
            collection.InsertOne(obj);
        }

        public void test()
        {
            FacialLandmarks facialLandmarks = new FacialLandmarks();
            Dictionary<PXCMFaceData.LandmarksGroupType, PXCMFaceData.LandmarkPoint[]> landmarksData = new Dictionary<PXCMFaceData.LandmarksGroupType, PXCMFaceData.LandmarkPoint[]>();
            PXCMFaceData.LandmarkPoint[] points = new PXCMFaceData.LandmarkPoint[20];
            points[0] = new PXCMFaceData.LandmarkPoint();
            landmarksData.Add(PXCMFaceData.LandmarksGroupType.LANDMARK_GROUP_JAW, points);
            CustomTime happenTS = new CustomTime();
            happenTS.absTS = DateTime.Now;
            happenTS.videoTS = 70;
            facialLandmarks.happenTS = happenTS;
            facialLandmarks.landmarksData = landmarksData;
            saveEntity(facialLandmarks);
        }

        public bool saveFacialExpression(FacialExpression facialExpression)
        {
            IMongoCollection<FacialExpression> collection = mongoDatabase.GetCollection<FacialExpression>("FacialExpression");
            collection.InsertOne(facialExpression);
            return true;
        }

        public bool saveFacialLandmarks(FacialLandmarks facialLandmarks)
        {
            throw new NotImplementedException();
        }

        public bool saveGestureData(GestureData gestureData)
        {
            throw new NotImplementedException();
        }

        public bool saveHandData(HandData handData)
        {
            throw new NotImplementedException();
        }

        public bool saveHeadData(HeadData headData)
        {
            throw new NotImplementedException();
        }

        public bool saveInteractionEvent(InteractionEvent interactionEvent)
        {
            throw new NotImplementedException();
        }

        public bool saveSpeechSpeed(SpeechSpeed speechSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
