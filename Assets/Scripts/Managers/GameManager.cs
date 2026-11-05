using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Game Info")]
    public int coinCollection = 0;

    void Start()
    {
        ServiceHub.Instance.LevelManager
            .NewTransition()
            .Load(SceneDataBase.Slots.MainMenu, SceneDataBase.Scenes.MainMenu)
            .WithOverlay()
            .Perform();
    }

}