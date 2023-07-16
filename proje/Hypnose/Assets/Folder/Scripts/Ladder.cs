using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool inside = false;
    public float speed = 3f;
    public FPSController player;
    public AudioSource sound;
    public Animator animator;

    // Camera variables
    public Camera playerCamera;
    public float lookSpeed = 2f;
    public float lookXLimit = 60f;
    private float rotationX = 0f;

    void Awake()
    {
        player = GetComponent<FPSController>();
    }

    void Start()
    {
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            SetLadderInteraction(true);
        }
        else if (col.gameObject.tag == "Ground" && inside)
        {
            SetLadderInteraction(false);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            SetLadderInteraction(false);
        }
    }

    void SetLadderInteraction(bool isInside)
    {
        player.enabled = !isInside;
        inside = isInside;

        animator.enabled = !isInside;
    }

    void Update()
    {
        if (inside)
        {
            if (Input.GetKey("s"))
            {
                player.transform.position += Vector3.down * speed * Time.deltaTime;
            }
            else if (Input.GetKey("w"))
            {
                if (player.transform.position.y < transform.position.y + 1f)
                {
                    player.transform.position += Vector3.up * speed * Time.deltaTime;
                    sound.Play();
                }
            }

            float rotationY = Input.GetAxis("Mouse X") * lookSpeed;
            player.transform.rotation *= Quaternion.Euler(0, rotationY, 0);

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            player.transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }
    }
}