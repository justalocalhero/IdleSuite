using UnityEngine;

public class PendingBuilding : MonoBehaviour
{
    public BuildingCount buildingCount { get; private set; }
    public WorkerCount builders;
    private float remaining;
    public float fireTime;

    public float Progress 
    {
        get 
        { 
            return 1 - Mathf.Clamp(remaining, 0, fireTime) / fireTime;
        }
    }

    private void Awake() 
    {
        buildingCount = GetComponentInParent<Building>().buildingCount;
    }

    private void Start() 
    {
        remaining = fireTime;
    }

    public void Update()
    {
        if(remaining > 0)
        {
            if(buildingCount.Pending != 0) remaining -= (builders.Count * Time.deltaTime);
        }        
        else
        {
            remaining = fireTime;

            if(buildingCount.Pending > 0)
            {
                buildingCount.Pending--;
                buildingCount.Count++;
            }
            if(buildingCount.Pending < 0)
            {
                buildingCount.Pending++;
                buildingCount.Count--;
            }
        }
    }
}
