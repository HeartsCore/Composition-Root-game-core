using System;


namespace TestAssigment.Data
{
    [Serializable]
    public class Buff
    {
        #region Fields
        public string icon;
        public int id;
        public string title;
        public BuffStat[] stats;
        #endregion
    }
}
