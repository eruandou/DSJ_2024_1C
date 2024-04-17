namespace Strategy
{
    public interface IFireWeapon
    {
        int Bullets { get; }
        void Shoot();
        void Reload();
    }
}