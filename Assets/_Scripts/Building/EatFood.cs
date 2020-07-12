using UnityEngine;

public class EatFood : MonoBehaviour
{
    public Resource workers;
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
            food.Consume = workers.Value;

            if(workers.Space <= 0) return;

            if(food.Value > 0) successes++;
            else successes -= 10;
            if(food.Value > workers.Value) successes += (food.Value / workers.Value);
            if(successes > workers.Value * 10 / fireTime) 
            {
                workers.Value++;
                successes = 0;
            }
            successes = Mathf.Clamp(successes, 0, successes);
        }
    }
}
