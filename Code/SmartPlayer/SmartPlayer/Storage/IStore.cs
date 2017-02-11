using SmartPlayer.Data;
using SmartPlayer.Data.InteractionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlayer.Storage
{
    interface IStore
    {
        void openSession(LearningSession s);

        void closeSession(LearningSession s);

        void saveMomentEvent(MomentEvent e);

        void savePeriodEvent(PeriodEvent e);
    }
}
