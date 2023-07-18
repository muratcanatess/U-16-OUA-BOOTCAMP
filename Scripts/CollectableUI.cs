using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableUI : MonoBehaviour
{
    [SerializeField] Image CircleImg;
    [SerializeField] TextMeshProUGUI txtProgress;

    private void Start()
    {
        txtProgress.text = 0.ToString();

    }

    public void UpdateProgress(float progress)
    {
        CircleImg.fillAmount = progress;
        txtProgress.text = Mathf.Floor(progress * 10).ToString();
    }
}


