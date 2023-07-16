using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool inReach;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
        }
    }

    private void Update()
    {
        if (inReach && Input.GetMouseButtonDown(0))
        {
            Collect();
        }
    }

    private void Collect()
    {
        gameObject.SetActive(false);
        playerInventory.CollectablesCollected();
    }
}
