using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpartaDungeon.Data
{
    public class DungeonLevel
    {
        public int Level { get; private set; }
        public int RecommendedDefense { get; private set; }
        public int Reward { get; private set; }
        public DungeonLevel(int level, int recommendedDefense,  int reward)
        {
            Level = level;
            RecommendedDefense = recommendedDefense;
            Reward = reward;
        }
    }
}
