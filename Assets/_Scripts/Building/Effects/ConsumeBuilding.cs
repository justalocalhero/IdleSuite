public class ConsumeBuilding : Effect
{
    private ConditionalFire conditionalFire;

    protected override void OnAwake()
    {
        conditionalFire = GetComponentInParent<Building>()
            .GetComponentInChildren<DestroyBuilding>()
            .GetComponent<ConditionalFire>();
    }

    public override void FireEffect(int fireCount)
    {
        conditionalFire.TryFire(fireCount);
    }
}
