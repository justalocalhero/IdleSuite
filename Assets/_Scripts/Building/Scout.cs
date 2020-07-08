using UnityEngine;

public class Scout : MonoBehaviour
{
    [System.Serializable]
    public struct LandValue
    {
        public Resource resource;
        public float chance;
    }

    public LandValue[] landValues;
    public float fireTime;
    private float nextFireTime;
    private BuildingCount buildingCount;
    private float progress = 0;
    private float landValueTotal;

    void Awake()
    {
        buildingCount = GetComponentInParent<Building>().buildingCount;
        buildingCount.onCountSet += UpdateFireTime;
    }

    void Start()
    {
        UpdateFireTime(buildingCount.Count);

        foreach(LandValue landValue in landValues)
        {
            landValueTotal += landValue.chance;
        }
    }

    void UpdateFireTime(int value)
    {
        if(value <= 0) nextFireTime = float.MaxValue;
        else nextFireTime = Time.time + fireTime;
    }

    void Update()
    {
        if(landValues.Length == 0) return;

        if(Time.time >= nextFireTime)
        {
            UpdateFireTime(buildingCount.Count);

            progress += buildingCount.Count;
            while(progress >= GetNeeded())
            {
                PushLand();
                progress = 0;
            }
        }
    }

    int GetNeeded()
    {
        int toReturn = 0;

        foreach(LandValue landValue in landValues)
        {
            toReturn += landValue.resource.Value;
        }

        return toReturn;
    }

    void PushLand()
    {
        float roll = UnityEngine.Random.Range(0, landValueTotal);

        foreach(LandValue landValue in landValues)
        {
            roll -= landValue.chance;
            if(roll <= 0) 
            {
                landValue.resource.Maximum++;
                landValue.resource.Value++;
                return;
            }
        }
    }
}