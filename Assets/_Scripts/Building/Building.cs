using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : HeirarchyNode
{
    public BuildingCount buildingCount;
    
    void Awake()
    {
        buildingCount.ResetBuilding();
    }
}
