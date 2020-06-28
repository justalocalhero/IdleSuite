public delegate void OnFire();

public interface IFirable
{
    event OnFire onFire;
    void Fire();
}