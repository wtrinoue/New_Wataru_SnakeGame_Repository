using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppleCountText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI appleText;

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        int count = ResultManager.Instance.GetCount();
        appleText.text = $"Apple: {count}";
    }
}
