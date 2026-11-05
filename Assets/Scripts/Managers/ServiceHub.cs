using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [SerializeField] private UiManager uiManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LevelManager levelManager;



    public UiManager UIManager => uiManager;
    public GameStateManager GameStateManager => gameStateManager;
    public GameManager GameManager => gameManager;
    public LevelManager LevelManager => levelManager;

    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

}
