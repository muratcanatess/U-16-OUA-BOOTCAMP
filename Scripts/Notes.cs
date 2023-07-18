using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] private Image noteImage;
    [SerializeField] private TextMeshProUGUI noteText;
    public GameObject MessagePanel;
    public bool Action = false;

    public void Start()
    {
        MessagePanel.SetActive(false);
        noteImage.enabled = false;
        noteText.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                MessagePanel.SetActive(false);
                Action = false;
                noteImage.enabled = true;
                noteText.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            MessagePanel.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            MessagePanel.SetActive(false);
            Action = false;
            noteImage.enabled = false;
            noteText.enabled = false;
        }
    }
}
