using System;


namespace TestAssigment.Data
{
    [Serializable]
    public class GameModel
    {
        #region Fields
        public int playersCount;
        public int buffCountMin;
        public int buffCountMax;
        public bool allowDuplicateBuffs;
        #endregion
    }
}

