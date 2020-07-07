using UnityEngine;

public class EatFood : MonoBehaviour
{
    public WorkerCount workers;
    public MetaResource food;
    public float fireTime;
    private float nextFireTime = float.MaxValue;
    private float successes = 0;

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
            food.Consume = workers.Count;
            if(food.Value > 0) successes++;
            else successes -= 10;
            if(successes > workers.Count * 10) 
            {
                workers.Count++;
                successes = 0;
            }
            successes = Mathf.Clamp(successes, 0, successes);
        }

    }

}
