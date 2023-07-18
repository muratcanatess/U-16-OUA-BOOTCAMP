using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScreen;
    public FPSController playerMovement; // Reference to the script controlling player movement
    public GameObject hud;

    public float health = 100f;

    void Start()
    {
        deathScreen.SetActive(false);
        hud.SetActive(true);
        playerMovement = player.GetComponent<FPSController>();
        Time.timeScale = 1f;

    }

    void Update()
    {
        if (health <= 0)
        {
            MeshRenderer[] meshRenderers = player.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer renderer in meshRenderers)
            {
                renderer.enabled = false;
            }

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            hud.SetActive(false);

            playerMovement.enabled = false; // Disable player movement script

            deathScreen.SetActive(true);

            Time.timeScale = 0f;

        }
    }
}
