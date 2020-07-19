namespace TestAssigment.Model
{
	public interface IGameSettingsModel
	{
		#region Fields
		int PlayersCount { set; }

		int BuffsCountMin { get; set; }

		int BuffsContMax { get; set; }

		bool AllowDuplicateBuffs { get; set; }
        #endregion
    }
}
