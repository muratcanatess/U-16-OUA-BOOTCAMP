using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightOnPlayer;
    public GameObject pickUpText;
    public AudioSource flashlightSound;

    public bool inReach;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        FlashlightOnPlayer.SetActive(false);
    }

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

    private void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            this.gameObject.SetActive(false);
            flashlightSound.Play();
            FlashlightOnPlayer.SetActive(true);
            pickUpText.SetActive(false);
        }
    }

}
