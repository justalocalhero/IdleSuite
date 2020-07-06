using UnityEngine;

public class PendingBuilding : MonoBehaviour
{
    public BuildingCount buildingCount { get; private set; }
    private WorkerManager workerManager;
    private float nextFireTime;
    private const float fireTime = 1f;
    public float Progress 
    {
        get 
        { 
            if(nextFireTime == float.MaxValue) return 0;
            return 1 - (nextFireTime - Time.time) / fireTime;
        }
    }

    private void Awake() 
    {
        buildingCount = GetComponentInParent<Building>().buildingCount;
        buildingCount.onPendingSet += UpdateNextFireTime;
        nextFireTime = float.MaxValue;
    }

    private void Start() 
    {
        UpdateNextFireTime(buildingCount.Pending);
    }

    public void UpdateNextFireTime(int pending)
    {
        if(pending == 0) nextFireTime = float.MaxValue;
        else if(nextFireTime == float.MaxValue) nextFireTime = Time.time + fireTime;
    }

    public void Update()
    {
        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f;
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
