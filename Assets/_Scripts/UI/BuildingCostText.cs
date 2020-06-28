using UnityEngine;
using TMPro;

public class BuildingCostText : MonoBehaviour
{
    private Building building;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        building = GetComponentInParent<Building>();

        building.onCountChanged += (int count) => UpdateText();

        UpdateText();        
    }

    private void UpdateText()
    {
        string nameString = "";
        string valueString = "";

        foreach(ResourceValue cost in building.costs)
        {
            nameString += cost.resource.name + "\n";
            valueString += cost.value + "\n";
        }

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }

}