using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool inReach;
    [SerializeField] bool allCollected;
    public PlayerInventory inventory;
    public float openRot, closeRot, speed;
    public GameObject chest;

    bool opening;

    void Start()
    {
        inReach= true;
    }

    void Update()
    {
        if(inventory.numberOfEasterEgg == inventory.maxNumberOfEasterEgg)
        {
            allCollected = true;
        }
        
        if (inReach && Input.GetButtonDown("Interact") && allCollected)
        {
            opening = true;
            
        }
    }
    void FixedUpdate()
    {
        if (opening)
        {
            Quaternion targetRotation = Quaternion.Euler(openRot, 0, 0);
            chest.transform.localRotation = Quaternion.RotateTowards(chest.transform.localRotation, targetRotation, speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
        }
    }
}
