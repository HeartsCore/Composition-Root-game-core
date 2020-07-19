using System.Collections.Generic;
using TestAssigment.Controllers;
using TestAssigment.Helpers;
using TestAssigment.Model;
using TestAssigment.Ui;


namespace TestAssigment.Factory
{
	public class PlayerControllerFactory : IPlayerControllerFactory
	{
		#region Fields
		public PlayerController PlayerController { get; }
		#endregion


		#region Class Life Cycle
		public PlayerControllerFactory(PlayerView[] playerView, PlayerPanelHierarchyBehaviour[] playerPanelHierarchies, IGameController gameController)
		{
			Dictionary<int, PlayerEntity> dictionary = new Dictionary<int, PlayerEntity>();
			for (int i = 0; i < playerView.Length; i++)
			{
				dictionary.Add(i, new PlayerEntity(new PlayerModel
				{
					PlayerPanelHierarchy = playerPanelHierarchies[i],
					PlayerId = i
				}, playerView[i]));
			}
			PlayerController = new PlayerController(dictionary, gameController);
		}
        #endregion
    }
}
