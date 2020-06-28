using UnityEngine;
using TMPro;

public class BuildingText : MonoBehaviour
{
    private Building building;
    private TextMeshProUGUI text;

    private void Start() 
    {
        building = GetComponentInParent<Building>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        building.onCountChanged += (int count) => UpdateText();

        UpdateText();        
    }

    private void UpdateText()
    {
        string toSet = building.name + " " + building.count;

        text.SetText(toSet);
    }
}
