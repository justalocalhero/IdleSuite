using UnityEngine;

public class Forage : MonoBehaviour
{
    public WorkerCount workers;
    public Resource food;
    public float fireTime;
    private float nextFireTime = float.MaxValue;
    
    void Start()
    {
        UpdateFireTime();
    }

    private void UpdateFireTime()
    {
        nextFireTime = Time.time + fireTime;
    }

    void Update()
    {
        if(Time.time > nextFireTime)
        {
            UpdateFireTime();
            food.Value += workers.Count;
        }
    }

}