public delegate void OnTryFire();

public interface IConditional
{
    bool CanFire { get; set; }
    event OnTryFire onTryFire;
    
}
