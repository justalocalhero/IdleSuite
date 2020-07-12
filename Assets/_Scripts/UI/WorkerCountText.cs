using UnityEngine;
using TMPro;

public class WorkerCountText : MonoBehaviour
{
    private Workers workers;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        workers = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<Workers>();
        workers.onChanged +=  UpdateText;

        UpdateText();
    }

    private void UpdateText()
    {
        string nameString = "";
        string valueString = "";     

        if(workers.Max > 0)
        {
            nameString = "Workers ";
            valueString = workers.Value + " / " + workers.Prefer;
        }

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }
}