using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject key;
    public GameObject pickUpText;
    public AudioSource keySound;

    KeyManager keyManager;

    public bool inReach;

    void Start()
    {
        keyManager = gameObject.GetComponent<KeyManager>();
        inReach = false;
        pickUpText.SetActive(false);    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
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
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyManager.GetKey();
            key.SetActive(false);
            keySound.Play();
            pickUpText.SetActive(false);
        }
    }
}
