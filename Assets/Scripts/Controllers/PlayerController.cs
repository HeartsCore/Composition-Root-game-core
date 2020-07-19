using System;
using System.Collections.Generic;
using TestAssigment.Helpers;
using TestAssigment.Events;
using UnityEngine;
using TestAssigment.Model;


namespace TestAssigment.Controllers
{
	public class PlayerController : IPlayerController
	{
		#region Private Data
		private IGameController _gameController;
		private IBuffCollector _buffCollector;
		#endregion


		#region Fields
		public Dictionary<int, PlayerEntity> Players { get; }
		#endregion


		#region Class Life Cycle
		public PlayerController(Dictionary<int, PlayerEntity> playerEntities, IGameController gameController)
		{
			Players = playerEntities;
			_gameController = gameController;
			foreach (KeyValuePair<int, PlayerEntity> keyValuePair in playerEntities)
			{
				keyValuePair.Value.PlayerView.PlayerID = keyValuePair.Value.PlayerModel.PlayerId;
				keyValuePair.Value.PlayerView.PlayerPanelHierarchy = keyValuePair.Value.PlayerModel.PlayerPanelHierarchy;
				_buffCollector = (keyValuePair.Value.PlayerModel.BuffCollector = new BuffCollector(_gameController));
				keyValuePair.Value.PlayerView.Start();
				SetDefaultCharacteristicsValue(keyValuePair.Value.PlayerModel);
				if (_gameController.TypeGame == TypeGame.GameWithBuffs)
				{
					_buffCollector.ApplyBuffsOnPlayer(keyValuePair.Value.PlayerModel, new Action<Dictionary<TypeCharacteristic, float>, IPlayerModel>(IncreasePlayerCharacteristicsValue));
				}
				keyValuePair.Value.PlayerView.OnPlayerButtonClicked += HandleClicked;
				keyValuePair.Value.PlayerModel.OnHealthChanged += OnPlayerModelOnOnHealthChanged;
			}
			_gameController.OnGameRestart += EndGame;
		}
		#endregion


		#region Methods
		public void EndGame()
		{
			foreach (KeyValuePair<int, PlayerEntity> keyValuePair in Players)
			{
				keyValuePair.Value.PlayerView.EndGame();
				keyValuePair.Value.PlayerView.OnPlayerButtonClicked -= HandleClicked;
				keyValuePair.Value.PlayerModel.OnHealthChanged -= OnPlayerModelOnOnHealthChanged;
				keyValuePair.Value.PlayerModel.BuffCollector.BuffsCollector.Clear();
				keyValuePair.Value.PlayerModel.BuffCollector.PlayerCharacteristics.Clear();
				List<int> buffNums = keyValuePair.Value.PlayerModel.BuffCollector.BuffNums;
				if (buffNums != null)
				{
					buffNums.Clear();
				}
			}
			Players.Clear();
			_buffCollector.BuffsCollector.Clear();
			_buffCollector.PlayerCharacteristics.Clear();
			List<int> buffNums2 = _buffCollector.BuffNums;
			if (buffNums2 != null)
			{
				buffNums2.Clear();
			}
			_gameController = null;
			_buffCollector = null;
		}

		private void SetDefaultCharacteristicsValue(IPlayerModel playerModel)
		{
			foreach (KeyValuePair<TypeCharacteristic, PlayerCharacteristics> keyValuePair in _buffCollector.PlayerCharacteristics)
			{
				switch (keyValuePair.Key)
				{
					case TypeCharacteristic.Health:
						playerModel.Health = keyValuePair.Value.Value;
						break;
					case TypeCharacteristic.Armor:
						playerModel.Armor = Mathf.RoundToInt(keyValuePair.Value.Value);
						break;
					case TypeCharacteristic.Attack:
						playerModel.AttackValue = Mathf.RoundToInt(keyValuePair.Value.Value);
						break;
					case TypeCharacteristic.Vampirism:
						playerModel.VampireValue = Mathf.RoundToInt(keyValuePair.Value.Value);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public void IncreasePlayerCharacteristicsValue(Dictionary<TypeCharacteristic, float> buffs, IPlayerModel playerModel)
		{
			foreach (KeyValuePair<TypeCharacteristic, float> keyValuePair in buffs)
			{
				switch (keyValuePair.Key)
				{
					case TypeCharacteristic.Health:
						playerModel.Health += keyValuePair.Value;
						break;
					case TypeCharacteristic.Armor:
						playerModel.Armor += Mathf.RoundToInt(keyValuePair.Value);
						break;
					case TypeCharacteristic.Attack:
						playerModel.AttackValue += Mathf.RoundToInt(keyValuePair.Value);
						break;
					case TypeCharacteristic.Vampirism:
						playerModel.VampireValue += Mathf.RoundToInt(keyValuePair.Value);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private void HandleClicked(object sender, PlayerButtonClickEventArgs e)
		{
			PlayerEntity playerEntity;
			PlayerEntity playerEntity2;
			if (this.Players.TryGetValue(e.AttackingId, out playerEntity) && Players.TryGetValue(e.DefencingId, out playerEntity2))
			{
				if (playerEntity.PlayerModel.Health < 1f)
				{
					playerEntity.PlayerModel.IsDead = true;
					playerEntity.PlayerView.IsDead = playerEntity.PlayerModel.IsDead;
					return;
				}
				if (playerEntity2.PlayerModel.Health < 1f)
				{
					playerEntity2.PlayerModel.IsDead = true;
					playerEntity2.PlayerView.IsDead = playerEntity2.PlayerModel.IsDead;
					return;
				}
				float num = (playerEntity2.PlayerModel.Armor > 0) ? ((float)playerEntity.PlayerModel.AttackValue * (1f - (float)playerEntity2.PlayerModel.Armor * 0.01f)) : ((float)playerEntity.PlayerModel.AttackValue);
				playerEntity2.PlayerModel.Health -= num;
				float num2 = (playerEntity.PlayerModel.VampireValue > 0) ? (num * (1f - (float)playerEntity.PlayerModel.VampireValue * 0.01f)) : 0f;
				playerEntity.PlayerModel.Health += num2;
			}
		}

		private void OnPlayerModelOnOnHealthChanged(object sender, PlayerHealthChangedEventArgs e)
		{
			SyncHealth();
		}

		private void SyncHealth()
		{
			foreach (KeyValuePair<int, PlayerEntity> keyValuePair in Players)
			{
				keyValuePair.Value.PlayerView.Health = keyValuePair.Value.PlayerModel.Health;
			}
		}
        #endregion

    }
}
