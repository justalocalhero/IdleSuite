using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceText : MonoBehaviour
{
    public Resource resource;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        resource.onValueSet += (int value) => UpdateText();
        UpdateText();
    }

    void UpdateText()
    {
        if(resource.lifeTimeValue <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            text.SetText(resource.name + " " + resource.Value);
        }
    }
}
