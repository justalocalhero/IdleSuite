public delegate void OnTryFire(int fireCount);

public interface IConditional
{
    int MaxFirable { get; set; }
    event OnTryFire onTryFire;
    
}
