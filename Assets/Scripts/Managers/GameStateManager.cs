using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public GameState currentState { get; private set; }

    public GameState previousState { get; private set; }

    [Header("Debug Active State")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }
    private void OnGameStateChanged(GameState previousState, GameState currentState)
    {
        switch (currentState)
        {
            case GameState.None:
                Time.timeScale = 0f;
                Debug.Log("This should never come up");
                break;

            case GameState.Init:
                Debug.Log("Initializing Game...");

                //Run logic here

                Debug.Log("Initialization Complete!");
                Debug.Log("Exiting Init State...");

                //Time.timeScale = 0f; //pauses game

                ServiceHub.Instance.UIManager.HideAllUI();

                SetState(GameState.MainMenu);
                break;


            case GameState.MainMenu:
                Time.timeScale = 1f; //can pause game here

                ServiceHub.Instance.UIManager.FindUI();
                ServiceHub.Instance.UIManager.ShowMainMenuUI();

                Debug.Log("MainMenu State Loaded!");
                break;

            case GameState.Gameplay:
                Time.timeScale = 1f; //can pause game here

                ServiceHub.Instance.UIManager.FindUI();
                ServiceHub.Instance.UIManager.ShowGameplayUI();

                Debug.Log("Gameplay State Loaded!");
                break;

            case GameState.GameOver:
                Time.timeScale = 1f; //can pause game here

                ServiceHub.Instance.UIManager.FindUI();
                ServiceHub.Instance.UIManager.ShowGameOverUI();

                Debug.Log("GameOver State Loaded!");
                break;
        }
    }

    public void Gameplay()
    {
        SetState(GameState.Gameplay);
    }

    public void GameOver()
    {
        if (currentState == GameState.Gameplay)
        {
            SetState(GameState.GameOver);
        }
    }

    public void MainMenu()
    {
        SetState(GameState.MainMenu);
    }
}

