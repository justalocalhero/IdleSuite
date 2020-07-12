using UnityEngine;

public class ConditionalFire : MonoBehaviour, IConditional, IFirable
{
    public int MaxFirable { get; set ; }

    public event OnTryFire onTryFire;
    public event OnFire onFire;

    public void Fire(int fireCount)
    {
        if(onFire != null) onFire(MaxFirable);

    }

    public void TryFire(int fireCount)
    {
        CanFire(fireCount);
        
        if(MaxFirable <= 0) return;

        if(onFire != null) onFire(MaxFirable);
    }

    public int CanFire(int fireCount)
    {
        MaxFirable = fireCount;

        if(onTryFire != null) onTryFire(fireCount);
        
        return MaxFirable;
    }
}
