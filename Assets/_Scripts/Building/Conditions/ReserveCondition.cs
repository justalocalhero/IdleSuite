public class ReserveCondition : Condition
{
    private ReserveCost reserveCost;

    protected override void OnAwake()
    {
        reserveCost = GetComponentInParent<Building>().GetComponentInChildren<ReserveCost>();
    }

    public override bool CanFire()
    {
        foreach(ResourceValue reserve in reserveCost.reserves)
        {
            if(reserve.resource.Free <= 0) return false;
        }

        return true;
    }
}
