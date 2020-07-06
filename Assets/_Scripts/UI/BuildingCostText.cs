using UnityEngine;
using TMPro;

public class BuildingCostText : MonoBehaviour
{
    private CostValues resourceCost;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        resourceCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<CostValues>();

        UpdateText();
    }

    private void UpdateText()
    {
        string nameString = "";
        string valueString = "";

        foreach(ResourceValue cost in resourceCost.GetValues())
        {
            nameString += cost.resource.name + "\n";
            valueString += cost.value + "\n";
        }

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }
}
