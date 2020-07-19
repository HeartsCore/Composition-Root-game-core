using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestAssigment;
using TestAssigment.Controllers;
using TestAssigment.Helpers;
using TestAssigment.Model;
using UnityEngine;

public class BuffCollectorEditModeTest 
{
    [Test]
    [Category("BuffCollector")]
    public void ApplyBuffsOnPlayer_True_AppliesBuffsOnPlayer()
    {
        // Assign
        Dictionary<int, PlayerEntity> dictionary = new Dictionary<int, PlayerEntity>();
        
        TypeGame typeGame = TypeGame.GameWithBuffs;
        IGameSettingsModel gameSettingsModel = new GameSettingsModel();
        IGameController gameController = new GameController(gameSettingsModel, typeGame);
        IBuffCollector BuffCollector = new BuffCollector(gameController);
        IPlayerModel playerModel = new PlayerModel()
        {
            PlayerPanelHierarchy = new GameObject().AddComponent<PlayerPanelHierarchyBehaviour>(),
            PlayerId = 1
        };
        PlayerController playerController = new PlayerController(dictionary, gameController);
        Dictionary<TypeCharacteristic, float> buffs = new Dictionary<TypeCharacteristic, float>();
        Action<Dictionary<TypeCharacteristic, float>, IPlayerModel> callback = new Action<Dictionary<TypeCharacteristic, float>, IPlayerModel>(playerController.IncreasePlayerCharacteristicsValue);
        
        // Act
        BuffCollector.ApplyBuffsOnPlayer(playerModel, callback);
        
        // Assert
        
    }
}
