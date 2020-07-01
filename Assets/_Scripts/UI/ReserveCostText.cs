using UnityEngine;
using TMPro;

public class ReserveCostText : MonoBehaviour
{
    private ReserveCost reserveCost;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        reserveCost = GetComponentInParent<Building>().GetComponentInChildren<ReserveCost>();

        UpdateText();
    }

    private void UpdateText()
    {
        string nameString = "";
        string valueString = "";

        foreach(ResourceValue cost in reserveCost.reserves)
        {
            nameString += cost.resource.name + "\n";
            valueString += cost.value + "\n";
        }

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }
}