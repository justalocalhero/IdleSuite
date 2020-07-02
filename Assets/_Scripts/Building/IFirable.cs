public delegate void OnFire(int fireCount);

public interface IFirable
{
    event OnFire onFire;
    //void Fire(int fireCount);
}