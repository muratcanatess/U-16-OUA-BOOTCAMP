using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door;
    public float openRot, closeRot, speed;
    public bool opening;

    public GameObject openText;
    //public GameObject keyInv;

    public AudioSource doorSound;
    public AudioSource lockedSound;

    private bool inReach;
    private bool opened = false;
    private BoxCollider doorCollider;

    [SerializeField] InventoryManager.AllItems requiredItem;


    private void Start()
    {
        inReach = false;
        openText.SetActive(false);
        doorCollider = GetComponent<BoxCollider>();
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
/*        if (keyInv.activeSelf)
        {
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }*/

        if (inReach && Input.GetButtonDown("Interact") && !opened)
        {
            OpenDoor();
        }
        else if (inReach && Input.GetButtonDown("Interact") && opened)
        {
            CloseDoor();
        }

        if (inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();
        }
    }

    private void OpenDoor()
    {
        if (HasRequiredItem(requiredItem))
        {
            opening = true;
            doorSound.Play();
            opened = true;
            doorCollider.enabled = false;
            openText.SetActive(false);
        }
    }


    private void CloseDoor()
    {
        opening = false;
        opened = false;
        doorCollider.enabled = true;
    }

    void FixedUpdate()
    {
        if (opening)
        {
            Quaternion targetRotation = Quaternion.Euler(0, openRot, 0);
            door.transform.localRotation = Quaternion.Lerp(door.transform.localRotation, targetRotation, speed * Time.fixedDeltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, closeRot, 0);
            door.transform.localRotation = Quaternion.Lerp(door.transform.localRotation, targetRotation, speed * Time.fixedDeltaTime);
        }
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if(InventoryManager.Instance.inventoyItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
