using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private static readonly DBHelper mInstance = new DBHelper();

        private DBHelper()
        {
            string dbAddr = ConfigurationManager.AppSettings["MongoDB_Server"].ToString();
            string dbName = ConfigurationManager.AppSettings["MongoDB_DBName"].ToString();

            //mongoClient = new MongoClient(dbAddr);
            mongoClient = new MongoClient(dbAddr);
            mongoDatabase = mongoClient.GetDatabase(dbName);

            BsonSerializer.RegisterSerializer(new EnumSerializer<PXCMFaceData.LandmarksGroupType>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<PXCMFaceData.LandmarkType>(BsonType.String));
            BsonSerializer.RegisterSerializer(new EnumSerializer<PXCMHandData.GestureStateType>(BsonType.String));
        }

        public static DBHelper getInstance()
        {
            return mInstance;
        }

        public void saveEntity<T> (T obj)
        {
            string typeName = obj.GetType().Name;
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(typeName);
            collection.InsertOne(obj);
        }

        public bool saveFacialExpression(FacialExpression facialExpression)
        {
            throw new NotImplementedException();
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
    }
}
