using System;
using TestAssigment.Helpers;
using TestAssigment.Model;


namespace TestAssigment.Controllers
{
	public interface IGameController
	{
		#region Fields
		IGameSettingsModel SettingsModel { get; }

		TestAssigment.Data.Data GameData { get; }

		TypeGame TypeGame { get; }
		
		event Action OnGameRestart;
        #endregion


        #region Methods
        void EndCurrentGame();
        #endregion
    }
}
