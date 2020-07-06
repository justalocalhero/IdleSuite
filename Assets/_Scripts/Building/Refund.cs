using System.Collections.Generic;
using UnityEngine;

public class Refund : MonoBehaviour
{
    private BuildingCount building;
    public List<ResourceValue> refundValues;

    void Start()
    {
        building = GetComponentInParent<Building>().buildingCount;
        building.onCountChanged += Fire;
    }
    
    public void Fire(int count) 
    {
        if(count >= 0) return;

        foreach(ResourceValue refundValue in refundValues)
        {
            refundValue.resource.Refund(refundValue.value * count * -1);
        }
    }
}