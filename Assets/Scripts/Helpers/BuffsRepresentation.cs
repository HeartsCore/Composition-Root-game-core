using System.Collections.Generic;
using TestAssigment.Data;
using UnityEngine;


namespace TestAssigment.Helpers
{
	public class BuffsRepresentation
	{
		#region Private Data
		private BuffStat[] _stats;
        #endregion


        #region Fields
        public string Title;
		public Sprite Icon;
		public Dictionary<TypeCharacteristic, float> BuffsDict;
		#endregion


		#region Class Life Cycle
		public BuffsRepresentation(string title, Sprite icon, BuffStat[] buffs)
		{
			Title = title;
			Icon = icon;
			_stats = buffs;
			CreateBuffsStatDictionary();
		}
		#endregion


		#region Methods
		private void CreateBuffsStatDictionary()
		{
			BuffsDict = new Dictionary<TypeCharacteristic, float>();
			foreach (BuffStat stats2 in this._stats)
			{
				BuffsDict.Add((TypeCharacteristic)stats2.statId, stats2.value);
			}
		}
        #endregion

    }
}

