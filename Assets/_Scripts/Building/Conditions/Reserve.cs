public class Reserve : Effect
{
    private ReserveValues reserveCost;

    protected override void OnAwake()
    {
        reserveCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<ReserveValues>();
    }

    public override void FireEffect(int fireCount)
    {
        foreach(ResourceValue reserve in reserveCost.GetValues())
        {
            reserve.resource.Reserved += reserve.value * fireCount;
        }
    }
}
