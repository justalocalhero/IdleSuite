using UnityEngine;

public class ReserveCondition : Condition
{
    private ReserveValues reserveCost;

    protected override void OnAwake()
    {
        reserveCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<ReserveValues>();
    }

    public override int CanFire(int fireCount)
    {
        int toReturn = fireCount;

        foreach(ResourceValue reserve in reserveCost.GetValues())
        {
            toReturn = Mathf.Min(toReturn, reserve.resource.Free);
        }

        return toReturn;
    }
}
