﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPlayer.Data.ContextData;
using SmartPlayer.Data.InteractionData;
using SmartPlayer.Data.RealSenseData;
using System.Configuration;
using MongoDB.Driver;

namespace SmartPlayer.DB
{
    class DBHelper : IDB
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
