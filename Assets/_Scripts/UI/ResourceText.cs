using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceText : MonoBehaviour
{
    public Resource resource;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        resource.onChanged += UpdateText;
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

            string nameString = resource.name;
            string valueString = resource.Free + " / " + resource.Maximum;
            if(resource.Reserved > 0) valueString += " : " + resource.Reserved + " in Use.";

            nameText.SetText(nameString);
            valueText.SetText(valueString);
        }
    }
}
