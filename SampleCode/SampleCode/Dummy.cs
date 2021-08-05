using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 더미 클래스
namespace SampleCode
{
    public enum StatType
    {
        None = 0,
    }

    public enum BattleType
    {
        None = 0,
    }

    public enum PetBuffConditionType
    {
        None = 0,
        BattleType,
        Dungeon,
    }

    public class DungeonData
    {        
        public int DungeonIndex { get; set; }

        public BattleType BattleType { get; set; }
    }

    public class PetBuffData
    {
        public PetBuffConditionType ConditionType { get; set; }
        public string[] ConditionValue { get; set; }
    }

    public class PetBuffDataContainer
    {
        public PetBuffData GetData(int index)
        {
            return null;
        }
    }

    public class TableDataManger
    {
        public static TableDataManger Instance
        {
            get { return GetInstance(); }
        }

        public PetBuffDataContainer PetBuffDataContainer { get; private set; }

        static TableDataManger _instance;

        static TableDataManger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TableDataManger();
            }
            return _instance;
        }
    }

}
