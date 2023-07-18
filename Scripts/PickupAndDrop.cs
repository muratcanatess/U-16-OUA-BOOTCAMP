using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    public GameObject cam;
    float maxpickupdistance = 5;
    GameObject itemcurrentlyholding;
    bool isholding = false;
    Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isholding)
            {
                Drop();
            }
            else
            {
                Pickup();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    public void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxpickupdistance))
        {
            if (hit.transform.tag == "Item")
            {
                if (isholding)
                    return;

                itemcurrentlyholding = hit.transform.gameObject;

                foreach (var c in itemcurrentlyholding.GetComponentsInChildren<Collider>())
                {
                    if (c != null)
                        c.enabled = false;
                }
                foreach (var r in itemcurrentlyholding.GetComponentsInChildren<Rigidbody>())
                {
                    if (r != null)
                        r.isKinematic = true;
                }

                itemcurrentlyholding.transform.parent = transform;
                itemcurrentlyholding.transform.localPosition = Vector3.zero;
                itemcurrentlyholding.transform.localEulerAngles = Vector3.zero;
                itemcurrentlyholding.transform.localScale = originalScale;

                isholding = true;
            }
        }
    }

    public void Drop()
    {
        if (!isholding)
            return;

        itemcurrentlyholding.transform.parent = null;
        foreach (var c in itemcurrentlyholding.GetComponentsInChildren<Collider>())
        {
            if (c != null)
                c.enabled = true;
        }
        foreach (var r in itemcurrentlyholding.GetComponentsInChildren<Rigidbody>())
        {
            if (r != null)
                r.isKinematic = false;
        }
        isholding = false;

        RaycastHit hitDown;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hitDown))
        {
            itemcurrentlyholding.transform.position = hitDown.point + cam.transform.forward * 2f;
        }

        Vector3 rotationEulerAngles = itemcurrentlyholding.transform.localEulerAngles;
        rotationEulerAngles.x = 0f;
        itemcurrentlyholding.transform.localEulerAngles = rotationEulerAngles;

        itemcurrentlyholding = null;
    }
}
