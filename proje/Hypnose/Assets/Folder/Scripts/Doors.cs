using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject keyInv;

    public AudioSource doorSound;
    public AudioSource lockedSound;

    private bool inReach;
    private bool opened = false;
    private bool hasKey;

    private void Start()
    {
        inReach = false;
        hasKey = false;
        openText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    private void Update()
    {
        if (keyInv.activeSelf)
        {
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }

        if (hasKey && inReach && Input.GetButtonDown("Interact") && !opened)
        {
            OpenDoor();
        }
        else if (inReach && Input.GetButtonDown("Interact") && opened)
        {
            CloseDoor();
        }

        if (!hasKey && inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();
        }
    }

    private void OpenDoor()
    {
        door.SetBool("open", true);
        door.SetBool("close", false);
        doorSound.Play();
        opened = true;
    }

    private void CloseDoor()
    {
        door.SetBool("open", false);
        door.SetBool("close", true);
        opened = false;
    }
}
