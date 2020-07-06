using UnityEngine;

public class Timer : MonoBehaviour
{
    private BuildingCount building;
    private ConditionalFire conditionalFire;
    public float fireTime;
    private float nextFireTime;

    private void Start() 
    {
        building = GetComponentInParent<Building>().buildingCount;
        conditionalFire = GetComponentInParent<ConditionalFire>();
        nextFireTime = Time.time + fireTime;
    }

    private void Update()
    {
        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireTime;
            conditionalFire.TryFire(building.Count);
        }
    }
}