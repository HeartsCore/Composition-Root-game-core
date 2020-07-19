namespace TestAssigment.Model
{
	public class GameSettingsModel : IGameSettingsModel
	{
		#region Private Data
		private int _playersCount;

		private int _buffsCountMin;

		private int _buffsContMax;

		private bool _allowDuplicateBuffs;
		#endregion


		#region Fields
		public int PlayersCount { set {_playersCount = value;} }

		public int BuffsCountMin { get { return _buffsCountMin; } set { _buffsCountMin = value; } }

		public int BuffsContMax { get { return _buffsContMax; } set { _buffsContMax = value; } }

		public bool AllowDuplicateBuffs { get { return _allowDuplicateBuffs; } set { _allowDuplicateBuffs = value; } }
        #endregion
    }
}
