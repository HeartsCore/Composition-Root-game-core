using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TestAssigment.Controllers;
using TestAssigment.Helpers;
using TestAssigment.Model;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests 
{
    private GameObject _managerGO;
    private PlayerController _controller;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        _managerGO = new GameObject();
        yield return null;
        IGameSettingsModel gameSettingsModel = new GameSettingsModel();
        TypeGame typeGame = TypeGame.GameWithBuffs;
        Dictionary<int, PlayerEntity> dictionary = new Dictionary<int, PlayerEntity>();
        IGameController gameController = new GameController(gameSettingsModel, typeGame);

        _controller = new PlayerController(dictionary, gameController);

    }

    [UnityTearDown]
    public IEnumerator Teardown()
    {
        GameObject.DestroyImmediate(_managerGO);
        yield return null;
    }

    [Test, Order(0)]
    public void Controller_Is_Not_Null()
    {
        Assert.IsNotNull(_controller);
    }
   
}
