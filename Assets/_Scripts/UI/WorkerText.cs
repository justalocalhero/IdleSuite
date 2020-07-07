using UnityEngine;
using TMPro;

public class WorkerText : MonoBehaviour
{
    public WorkerCount workerCount;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        workerCount.onChanged += UpdateText;
        UpdateText();
    }

    void UpdateText()
    {
        if(workerCount.Count > 0)
        {
            gameObject.SetActive(true);
        }


        string nameString = workerCount.name;
        string valueString = workerCount.Count.ToString();

        nameText.SetText(nameString);
        valueText.SetText(valueString);
        
    }
}