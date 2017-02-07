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
        void saveMomentEvent(MomentEvent e);

        void savePeriodEvent(PeriodEvent e);

        void saveLearningSession(LearningSession ls);
    }
}
