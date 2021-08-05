using System;

namespace SampleCode
{
    // 장비 아이템 외에 능력치를 올려주는 버프에서 사용할 인터페이스 추가
    public interface IExtraStatData
    {
        StatType StatType { get; }
        int StatValue { get; }
        bool CheckActiveCondition(DungeonData data);
    }

    // 펫 버프 캐싱에 사용할 부모 클래스
    // 차후 스킬 버프가 추가 될 경우 조건 체크는 동일하기 때문에
    // CheckActiveCondition는 부모 클래스에 구현
    public class CachedPetBuffDataBase
    {
        public int Index { get; set; }

        public bool CheckActiveCondition(DungeonData data)
        {
            if (data == null)
                return false;

            var petBuffData = TableDataManger.Instance.PetBuffDataContainer.GetData(Index);
            if (petBuffData == null)
                return false;

            var isActive = false;

            switch (petBuffData.ConditionType)
            {
                case PetBuffConditionType.None:
                    {
                        isActive = true;
                    }
                    break;
                case PetBuffConditionType.BattleType:   
                    {
                        // petBuffData.ConditionValue값이 현재 던전의 BattleType과 같으면 버프 적용
                        isActive = IsActiveBattleType(petBuffData.ConditionValue, data.BattleType);
                    }
                    break;
                case PetBuffConditionType.Dungeon:
                    {
                        // petBuffData.ConditionValue값이 현재 던전의 DungeonIndex와 같으면 버프 적용
                        isActive = IsActiveCampaign(petBuffData.ConditionValue, data.DungeonIndex);
                    }
                    break;
            }

            return isActive;
        }

        // 활성 조건 체크
        #region active condition Check
        bool IsActiveBattleType(string[] conditionValue, BattleType currentBattleType)
        {
            var isActive = false;
            // ...
            return isActive;
        }

        bool IsActiveCampaign(string[] conditionValue, int currentDungeonIndex)
        {
            var isActive = false;
            // ...
            return isActive;
        }
        #endregion
    }

    // CachedPetStatBuffData 을 상속받지 못하게 sealed 사용
    public sealed class CachedPetStatBuffData : CachedPetBuffDataBase, IExtraStatData
    {
        public StatType StatType { get; set; }
        public int StatValue { get; set; }

        StatType IExtraStatData.StatType { get { return StatType; } }
        int IExtraStatData.StatValue { get { return StatValue; } }

        bool IExtraStatData.CheckActiveCondition(DungeonData data)
        {
            var result = CheckActiveCondition(data);
            return result;
        }
    }
}
