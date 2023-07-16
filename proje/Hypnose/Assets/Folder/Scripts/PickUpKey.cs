using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject key;
    public GameObject inventory;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;

    void Start()
    {
        inReach= false; 
        pickUpText.SetActive(false);
        inventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true; 
            pickUpText.SetActive(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact")) 
        {
            key.SetActive(false);
            keySound.Play();
            inventory.SetActive(true);
            pickUpText.SetActive(false);
        }
    }
}
