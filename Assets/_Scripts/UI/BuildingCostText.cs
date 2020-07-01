using UnityEngine;
using TMPro;

public class BuildingCostText : MonoBehaviour
{
    private ResourceCost resourceCost;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        resourceCost = GetComponentInParent<Building>().GetComponentInChildren<ResourceCost>();

        UpdateText();
    }

    private void UpdateText()
    {
        string nameString = "";
        string valueString = "";

        foreach(ResourceValue cost in resourceCost.GetCost())
        {
            nameString += cost.resource.name + "\n";
            valueString += cost.value + "\n";
        }

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }
}