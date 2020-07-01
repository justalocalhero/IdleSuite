public class MaximumCount : Condition
{
    public int maximumCount;
    private Building building;

    protected override void OnAwake()
    {
        building = GetComponentInParent<Building>();
    }

    public override bool CanFire()
    {
        return building.Count < maximumCount;
    }
}
