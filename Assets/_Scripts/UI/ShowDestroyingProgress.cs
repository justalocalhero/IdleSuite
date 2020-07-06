using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowDestroyingProgress : MonoBehaviour
{
    private bool asleep;
    private Slider slider;
    private PendingBuilding pendingBuilding;
    public  TextMeshProUGUI text;

    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        pendingBuilding = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<PendingBuilding>();
    }

    void Start()
    {
        pendingBuilding.buildingCount.onPendingSet += UpdateAsleep;
        UpdateAsleep(pendingBuilding.buildingCount.Count);
    }

    void UpdateAsleep(int pending)
    {
        asleep = pending >= 0;
        if(asleep) 
        {
            slider.value = 0;
            text.SetText("");
        }
        else
        {
            text.SetText((-pending).ToString());
        }
    }

    void Update()
    {
        if(asleep) return;
        slider.value = pendingBuilding.Progress;
    }
}