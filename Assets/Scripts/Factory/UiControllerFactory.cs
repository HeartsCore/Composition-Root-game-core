using System.Collections.Generic;
using TestAssigment.Controllers;
using TestAssigment.Helpers;
using TestAssigment.Ui;


namespace TestAssigment.Factory
{
	public class UiControllerFactory
	{
		#region Fields
		public List<UiController> UiController { get; }
		#endregion


		#region Class Life Cycle
		public UiControllerFactory(IUiView[] uiView, IPlayerController playerController, IGameController gameController)
		{
			int num = 0;
			foreach (IUiView uiView2 in uiView)
			{
				PlayerEntity playerEntity;
				playerController.Players.TryGetValue(num++, out playerEntity);
				UiController = new List<UiController>();
				UiController.Add(new UiController(uiView2, (playerEntity != null) ? playerEntity.PlayerModel : null, gameController));
			}
		}
        #endregion
    }
}
