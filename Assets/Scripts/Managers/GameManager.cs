using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("RayCast Settings")]
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float maxDistance = 50f;

    [Header("RayCast Info")]
    [SerializeField] private GameObject lastTargetHit;
    [SerializeField] private float lastTargetDistance;

    [Header("Coin")]
    public int coinCollection = 0;

    void Start()
    {
        ServiceHub.Instance.LevelManager
            .NewTransition()
            .Load(SceneDataBase.Slots.MainMenu, SceneDataBase.Scenes.MainMenu)
            .WithOverlay()
            .Perform();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if(hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    lastTargetHit = hit.collider.gameObject;
                    lastTargetDistance = hit.distance;

                    interactable.Interact();
                }
            }
        }
    }
}