public class Reserve : Effect
{
    private ReserveCost reserveCost;

    protected override void OnAwake()
    {
        reserveCost = GetComponentInParent<Building>().GetComponentInChildren<ReserveCost>();
    }

    public override void FireEffect()
    {
        foreach(ResourceValue reserve in reserveCost.reserves)
        {
            reserve.resource.Reserved += reserve.value;
        }
    }
}
