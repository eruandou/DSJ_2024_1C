namespace Prototype
{
    public class BulletInfo : ICloneable
    {
        public float CurrentSpeed { get; }
        public string Owner { get; }
        public string Instigator { get; }

        public BulletInfo(float currentSpeed, string owner, string instigator)
        {
            CurrentSpeed = currentSpeed;
            Owner = owner;
            Instigator = instigator;
        }

        public ICloneable Clone()
        {
            var newBulletInfo = new BulletInfo(CurrentSpeed, Owner, Instigator);
            return newBulletInfo;
        }
    }
}