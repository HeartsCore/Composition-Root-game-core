using TestAssigment.Controllers;
using TestAssigment.Factory;
using TestAssigment.Helpers;
using TestAssigment.Ui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TestAssigment.Main
{
	public class MainBehaviour : MonoBehaviour
	{
		#region Private Data
		private PlayerView[] _playerView;
		private UiView[] _uiView;
		private IGameController _gameController;
		#endregion


		#region Fields
		public PlayerPanelHierarchyBehaviour[] playerPanelHierarchies;
		public Button gameWithoutBuffs;
		public Button gameWithBuffs;
		#endregion


		#region Unity Methods
		private void Awake()
		{
			gameWithBuffs.onClick.AddListener(new UnityAction(StartGameWithBuffs));
			gameWithoutBuffs.onClick.AddListener(new UnityAction(StartGameWithoutBuffs));
			StartGameWithoutBuffs();
		}
		#endregion


		#region Methods
		private void StartGameWithoutBuffs()
		{
			IGameController gameController = _gameController;
			if (gameController != null)
			{
				gameController.EndCurrentGame();
			}
			_playerView = UnityEngine.Object.FindObjectsOfType<PlayerView>();
			_uiView = UnityEngine.Object.FindObjectsOfType<UiView>();
			IGameControllerFactory gameControllerFactory = new GameControllerFactory(TypeGame.GameWithoutBuffs);
			_gameController = gameControllerFactory.GameController;
			IPlayerControllerFactory playerControllerFactory = new PlayerControllerFactory(_playerView, playerPanelHierarchies, _gameController);
			IUiView[] uiView = _uiView;
			new UiControllerFactory(uiView, playerControllerFactory.PlayerController, _gameController);
		}

		private void StartGameWithBuffs()
		{
			IGameController gameController = _gameController;
			if (gameController != null)
			{
				gameController.EndCurrentGame();
			}
			_playerView = UnityEngine.Object.FindObjectsOfType<PlayerView>();
			_uiView = UnityEngine.Object.FindObjectsOfType<UiView>();
			IGameControllerFactory gameControllerFactory = new GameControllerFactory(TypeGame.GameWithBuffs);
			_gameController = gameControllerFactory.GameController;
			IPlayerControllerFactory playerControllerFactory = new PlayerControllerFactory(_playerView, playerPanelHierarchies, _gameController);
			IUiView[] uiView = _uiView;
			new UiControllerFactory(uiView, playerControllerFactory.PlayerController, _gameController);
		}
        #endregion
    }
}
