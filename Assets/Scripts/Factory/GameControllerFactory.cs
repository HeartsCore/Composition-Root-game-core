using TestAssigment.Controllers;
using TestAssigment.Helpers;
using TestAssigment.Model;


namespace TestAssigment.Factory
{
	public class GameControllerFactory : IGameControllerFactory
	{
		#region Fields
		public IGameController GameController { get; }
		#endregion


		#region Class Life Cycle
		public GameControllerFactory(TypeGame typeGame)
		{
			GameController = new GameController(new GameSettingsModel(), typeGame);
		}
        #endregion
    }
}
