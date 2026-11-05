using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    [SerializeField] private float waitTime = 2f;

    [SerializeField] private bool randomWaitTime;

    private bool canClick = true;

    public void Interact()
    {
        if (canClick)
        {
            ServiceHub.Instance.GameManager.coinCollection++;

            StartCoroutine(RespawnCoin());
        }

    }

    IEnumerator RespawnCoin()
    {
        canClick = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        if (randomWaitTime)
        {
            int randomInt = Random.Range(1, 4);
            yield return new WaitForSeconds(randomInt);
        }

        else yield return new WaitForSeconds(waitTime);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;

        canClick = true;

    }
}
