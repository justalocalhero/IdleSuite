using UnityEngine;

public class Timer : MonoBehaviour
{
    private IFirable firable;
    public float fireTime;
    private float nextFireTime;

    private void Start() 
    {
        firable = GetComponentInParent<IFirable>();
        nextFireTime = Time.time + fireTime;
    }

    private void Update()
    {
        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireTime;
            firable.Fire();
        }
    }
}