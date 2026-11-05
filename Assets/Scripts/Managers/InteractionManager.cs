using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [Header("RayCast Settings")]
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float maxDistance = 50f;

    [Header("RayCast Info")]
    [SerializeField] private GameObject lastTargetHit;
    [SerializeField] private float lastTargetDistance;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance, targetLayer))
            {
                if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    lastTargetHit = hit.collider.gameObject;
                    lastTargetDistance = hit.distance;

                    interactable.Interact();
                }
            }
        }
    }

    #region buttons
    public void ToMainMenu()
    {
        ServiceHub.Instance.LevelManager
            .NewTransition()
            .Load(SceneDataBase.Slots.MainMenu, SceneDataBase.Scenes.MainMenu, setActive: true)
            .Unload(SceneDataBase.Slots.Session)
            .Unload(SceneDataBase.Slots.SessionContent)
            .WithClearUnusedAssets()
            .WithOverlay()
            .Perform();

        ServiceHub.Instance.GameStateManager.MainMenu();
    }

    public void ToStart()
    {
        ServiceHub.Instance.LevelManager
            .NewTransition()
            .Load(SceneDataBase.Slots.Session, SceneDataBase.Scenes.Session)
            .Load(SceneDataBase.Slots.SessionContent, SceneDataBase.Scenes.Gameplay, setActive: true)
            .Unload(SceneDataBase.Slots.MainMenu)
            .WithOverlay()
            .Perform();

        ServiceHub.Instance.GameStateManager.Gameplay();
    }

    public void ToGameplay()
    {
        ServiceHub.Instance.LevelManager
            .NewTransition()
            .Load(SceneDataBase.Slots.SessionContent, SceneDataBase.Scenes.Gameplay, setActive: true)
            .WithOverlay()
            .Perform();

        ServiceHub.Instance.GameStateManager.Gameplay();
    }

    public void ToGameOver()
    {
        ServiceHub.Instance.LevelManager
            .NewTransition()
            .Load(SceneDataBase.Slots.SessionContent, SceneDataBase.Scenes.GameOver, setActive: true)
            .WithOverlay()
            .Perform();

        ServiceHub.Instance.GameStateManager.GameOver();
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
