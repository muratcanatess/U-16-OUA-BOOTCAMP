using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class OutlineSelection : MonoBehaviour
{
    [SerializeField] GameObject dotImg;
    [SerializeField] GameObject circleImg;

    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;

    private void Start()
    {
        dotImg.SetActive(true);
        circleImg.SetActive(false);
    }

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            dotImg.SetActive(true);
            circleImg.SetActive(false);
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") || highlight.CompareTag("Item")  && highlight != selection)
            {
                dotImg.SetActive(false);
                circleImg.SetActive(true);

                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;

                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
                }
            }
            else
            {
                highlight = null;
            }
        }

        /*// Selection
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = raycastHit.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
        }*/
    }

}
