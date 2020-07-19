using System;
using TestAssigment.Events;
using TestAssigment.Model;
using TestAssigment.Ui;


namespace TestAssigment.Controllers
{
	public class UiController
	{
		#region Private Data
		private IPlayerModel _playerModel;
		private IUiView _uiView;
		private IGameController _gameController;
		private enum SyncType
		{
			Health,
			Armor,
			AttackValue,
			VampireValue,
			StatsPanel
		}
		#endregion


		#region Class Life Cycle
		public UiController(IUiView uiView, IPlayerModel playerModel, IGameController gameController)
		{
			_gameController = gameController;
			_playerModel = playerModel;
			_uiView = uiView;
			InitView();
			_uiView.BuffCollector = playerModel.BuffCollector;
			_uiView.Start();
			_gameController.OnGameRestart += EndGame;
		}
		#endregion


		#region Methods
		private void EndGame()
		{
			_playerModel.OnHealthChanged -= OnPlayerModelOnOnHealthChanged;
			_playerModel.OnArmorChanged -= OnPlayerModelOnOnArmorChanged;
			_playerModel.OnAttackValueChanged -= OnPlayerModelOnOnAttackValueChanged;
			_playerModel.OnVampireValueChanged -= OnPlayerModelOnOnVampireValueChanged;
			_playerModel = null;
			_gameController = null;
			_uiView.EndGame();
			_uiView = null;
		}

		private void InitView()
		{
			SyncAll();
			_playerModel.OnHealthChanged += OnPlayerModelOnOnHealthChanged;
			_playerModel.OnArmorChanged += OnPlayerModelOnOnArmorChanged;
			_playerModel.OnAttackValueChanged += OnPlayerModelOnOnAttackValueChanged;
			_playerModel.OnVampireValueChanged += OnPlayerModelOnOnVampireValueChanged;
		}

		private void OnPlayerModelOnOnVampireValueChanged(object sender, PlayerVampireValueChangedEventArgs e)
		{
			Sync(SyncType.VampireValue);
		}

		private void OnPlayerModelOnOnAttackValueChanged(object sender, PlayerAttackValueChangedEventArgs e)
		{
			Sync(SyncType.AttackValue);
		}

		private void OnPlayerModelOnOnArmorChanged(object sender, PlayerArmorChangedEventArgs e)
		{
			Sync(SyncType.Armor);
		}

		private void OnPlayerModelOnOnHealthChanged(object sender, PlayerHealthChangedEventArgs e)
		{
			Sync(SyncType.Health);
		}

		private void SyncAll()
		{
			Sync(SyncType.StatsPanel);
			Sync(SyncType.Health);
			Sync(SyncType.Armor);
			Sync(SyncType.AttackValue);
			Sync(SyncType.VampireValue);
		}

		private void Sync(SyncType syncType)
		{
			switch (syncType)
			{
				case SyncType.Health:
					_uiView.Health = _playerModel.Health;
					return;
				case SyncType.Armor:
					_uiView.Armor = _playerModel.Armor;
					return;
				case SyncType.AttackValue:
					_uiView.AttackValue = _playerModel.AttackValue;
					return;
				case SyncType.VampireValue:
					_uiView.VampireValue = _playerModel.VampireValue;
					return;
				case SyncType.StatsPanel:
					_uiView.PlayerPanelHierarchy = _playerModel.PlayerPanelHierarchy;
					return;
				default:
					throw new ArgumentOutOfRangeException("syncType", syncType, null);
			}
		}
        #endregion

    }
}
