using System.Collections.Generic;
using UnityEngine;

public class CostCondition : Condition
{
    private CostValues resouceCost;

    protected override void OnAwake()
    {
        resouceCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<CostValues>();
    }

    public override int CanFire(int fireCount)
    {
        List<ResourceValue> costs = resouceCost.GetValues();

        int toReturn = fireCount;

        foreach(ResourceValue cost in costs)
        {
            toReturn = Mathf.Min(cost.resource.Value / cost.value, toReturn);
        }

        return toReturn;
    }
}
