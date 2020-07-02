using UnityEngine;

public abstract class Condition : MonoBehaviour, ICondition
{
    IConditional conditional;

    private void Awake()
    {
        conditional = GetComponentInParent<IConditional>();
        conditional.onTryFire += HandleTryFire;

        OnAwake();
    }

    private void HandleTryFire(int fireCount)
    {
        conditional.MaxFirable = Mathf.Min(conditional.MaxFirable, CanFire(fireCount));
    }
    
    protected virtual void OnAwake()
    {

    }

    public abstract int CanFire(int fireCount);
}