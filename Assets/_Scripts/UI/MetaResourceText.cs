using UnityEngine;
using TMPro;

public class MetaResourceText : MonoBehaviour
{
    public MetaResource metaResource;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        metaResource.onChanged += UpdateText;
        UpdateText();
    }

    void UpdateText()
    {
        if(metaResource.Value > 0)
        {
            gameObject.SetActive(true);
        }

        string nameString = metaResource.name;
        string valueString = metaResource.Value.ToString();

        foreach(MetaResource.MetaResourceData data in metaResource.resources)
        {
            if(data.resource.lifeTimeValue <= 0) continue;
            string del = "\n   ";
            nameString += del + data.resource.name;
            valueString += del + data.resource.Free + " / " + data.resource.Maximum;
        }        

        nameText.SetText(nameString);
        valueText.SetText(valueString);        
    }
}

