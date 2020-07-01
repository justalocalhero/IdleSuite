public class MinimumCount : Condition
{
    public int minimumCount;
    private Building building;

    protected override void OnAwake()
    {
        building = GetComponentInParent<Building>();
    }

    public override bool CanFire()
    {
        return building.Count >= minimumCount;
    }
}