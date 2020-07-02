using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    IFirable firable;

    private void Awake()
    {
        firable = GetComponentInParent<IFirable>();
        firable.onFire += FireEffect;
        OnAwake();
    }
    
    protected virtual void OnAwake() { }

    public abstract void FireEffect(int FireCount);
}