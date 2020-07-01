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

    private void HandleTryFire()
    {
        conditional.CanFire &= CanFire();
    }
    
    protected virtual void OnAwake()
    {

    }

    public abstract bool CanFire();
}