using System;
using System.Collections.Generic;
using System.IO;
using TestAssigment.Controllers;
using TestAssigment.Data;
using TestAssigment.Model;
using UnityEngine;


namespace TestAssigment.Helpers
{
	public class BuffCollector : IBuffCollector
	{
		#region Private Data
		private readonly IGameController _gameController;
		#endregion


		#region Fields
		public Dictionary<TypeCharacteristic, PlayerCharacteristics> PlayerCharacteristics { get; private set; }

		public Dictionary<TypeBuff, BuffsRepresentation> BuffsCollector { get; private set; }

		public List<int> BuffNums { get; private set; }
		#endregion


		#region Class Life Cycle
		public BuffCollector(IGameController gameController)
		{
			_gameController = gameController;
			CreateDefaultCharacteristics();
			CreateDefaultBuffs();
		}
		#endregion


		#region Methods
		public void ApplyBuffsOnPlayer(IPlayerModel playerToBuffing, Action<Dictionary<TypeCharacteristic, float>, IPlayerModel> callback)
		{
			int count = RandomGenerator.GenerateBuffsCount(_gameController.SettingsModel.BuffsCountMin, _gameController.SettingsModel.BuffsContMax);
			BuffNums = RandomGenerator.GenerateListNumBuffs(count, _gameController.SettingsModel.AllowDuplicateBuffs);
			foreach (int key in this.BuffNums)
			{
				BuffsRepresentation buffsRepresentation;
				BuffsCollector.TryGetValue((TypeBuff)key, out buffsRepresentation);
				callback((buffsRepresentation != null) ? buffsRepresentation.BuffsDict : null, playerToBuffing);
			}
		}

		private void CreateDefaultCharacteristics()
		{
			PlayerCharacteristics = new Dictionary<TypeCharacteristic, PlayerCharacteristics>();
			foreach (Stat characteristics2 in _gameController.GameData.stats)
			{
				Sprite icon = Resources.Load<Sprite>(Path.Combine("Icons", characteristics2.icon));
				PlayerCharacteristics value = new PlayerCharacteristics(characteristics2.title, characteristics2.value, icon);
				PlayerCharacteristics.Add((TypeCharacteristic)characteristics2.id, value);
			}
		}

		private void CreateDefaultBuffs()
		{
			BuffsCollector = new Dictionary<TypeBuff, BuffsRepresentation>();
			foreach (Buff buffs2 in this._gameController.GameData.buffs)
			{
				Sprite icon = Resources.Load<Sprite>(Path.Combine("Icons", buffs2.icon));
				BuffsRepresentation value = new BuffsRepresentation(buffs2.title, icon, buffs2.stats);
				BuffsCollector.Add((TypeBuff)buffs2.id, value);
			}
		}
        #endregion

    }
}
