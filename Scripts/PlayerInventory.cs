using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int numberOfCollectables;
    public int numberOfEasterEgg;
    public GameObject totalText;
    public CollectableUI gameUI;
    public GameObject portal;
    public float displayDuration = 2f;

    public int maxNumberOfCollectables = 10;
    public int maxNumberOfEasterEgg = 5;

    private Coroutine displayCoroutine;

    private void Start()
    {
        totalText.SetActive(false);
        numberOfCollectables = 0;
        portal.SetActive(false);
    }

    public void CollectablesCollected()
    {
        numberOfCollectables++;

        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }

        float progressValue = (float)numberOfCollectables / maxNumberOfCollectables;
        gameUI.UpdateProgress(progressValue);

        if (numberOfCollectables >= maxNumberOfCollectables)
        {
            portal.SetActive(true);
        }
    }

    public void EasterEggCollected()
    {
        numberOfEasterEgg++;

        TextMeshProUGUI textMeshPro = totalText.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Easter Egg #" + numberOfEasterEgg.ToString() + " Out Of 5";

        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }

        displayCoroutine = StartCoroutine(DisplayEasterEggText());

        float progressValue = (float)numberOfEasterEgg / maxNumberOfEasterEgg;
        gameUI.UpdateProgress(progressValue);
    }

    private IEnumerator DisplayEasterEggText()
    {
        totalText.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        totalText.SetActive(false);
    }
}
