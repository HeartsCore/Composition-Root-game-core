using System;
using TestAssigment.Helpers;
using TestAssigment.Model;
using UnityEngine;


namespace TestAssigment.Controllers
{
	public class GameController : IGameController
	{
		#region Private Data
		private TextAsset _jsonTextAsset;
		#endregion

		#region Fields
		public IGameSettingsModel SettingsModel { get; }

		public TestAssigment.Data.Data GameData { get; private set; }

		public TypeGame TypeGame { get; }

		public event Action OnGameRestart = delegate ()
		{
		};
		#endregion


		#region Class Life Cycle
		public GameController(IGameSettingsModel gameSettingsModel, TypeGame typeGame)
		{
			SettingsModel = gameSettingsModel;
			TypeGame = typeGame;
			_jsonTextAsset = Resources.Load<TextAsset>("data");
			if (_jsonTextAsset == null)
			{
				throw new NullReferenceException("_jsonTextAsset", null);
			}
			GameData = JsonUtility.FromJson<TestAssigment.Data.Data>(_jsonTextAsset.text);
			SetupSettings();
		}
		#endregion


		#region Methods
		private void SetupSettings()
		{
			SettingsModel.PlayersCount = GameData.settings.playersCount;
			SettingsModel.BuffsCountMin = GameData.settings.buffCountMin;
			SettingsModel.BuffsContMax = GameData.settings.buffCountMax;
			SettingsModel.AllowDuplicateBuffs = GameData.settings.allowDuplicateBuffs;
		}

		public void EndCurrentGame()
		{
			OnGameRestart();
		}
        #endregion

    }
}
