using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int numberOfCollectables;
    public GameObject totalText;
    public float displayDuration = 2f;

    private Coroutine displayCoroutine;

    private void Start()
    {
        totalText.SetActive(false);
    }

    public void CollectablesCollected()
    {
        numberOfCollectables++;

        TextMeshProUGUI textMeshPro = totalText.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Picked Up Collectable #" + numberOfCollectables.ToString();

        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }

        displayCoroutine = StartCoroutine(DisplayCollectableText());
    }

    private IEnumerator DisplayCollectableText()
    {
        totalText.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        totalText.SetActive(false);
    }
}
