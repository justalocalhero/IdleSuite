using UnityEngine;

public class ConsumesBuilding : Condition
{
    private ConditionalFire conditionalFire;

    protected override void OnAwake()
    {
        conditionalFire = GetComponentInParent<Building>()
            .GetComponentInChildren<DestroyBuilding>()
            .GetComponent<ConditionalFire>();
    }

    public override int CanFire(int fireCount)
    {
        return conditionalFire.CanFire(fireCount);
    }
}