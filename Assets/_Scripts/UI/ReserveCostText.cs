using UnityEngine;
using TMPro;

public class ReserveCostText : MonoBehaviour
{
    private ReserveValues reserveCost;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        reserveCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<ReserveValues>();
        UpdateText();
    }

    private void UpdateText()
    {
        string nameString = "";
        string valueString = "";

        foreach(ResourceValue cost in reserveCost.GetValues())
        {
            nameString += cost.resource.name + "\n";
            valueString += cost.value + "\n";
        }

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }
}