using UnityEngine;
using TMPro;

public class BuildingText : MonoBehaviour
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
        nameText.SetText(building.name);
        valueText.SetText(building.Count.ToString());
    }
}
