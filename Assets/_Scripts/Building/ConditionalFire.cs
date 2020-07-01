using UnityEngine;

public class ConditionalFire : MonoBehaviour, IConditional, IFirable
{
    public bool CanFire { get; set; }
    public event OnTryFire onTryFire;
    public event OnFire onFire;

    public void Fire()
    {
        throw new System.NotImplementedException();
    }

    public void TryFire()
    {
        CanFire = true;

        if(onTryFire != null) onTryFire();

        if(!CanFire) return;

        if(onFire != null) onFire();
    }
}
