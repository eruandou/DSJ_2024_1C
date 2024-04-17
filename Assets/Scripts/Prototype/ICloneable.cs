namespace Prototype
{
    public interface ICloneable
    {
        ICloneable Clone();
    }

    public interface ICloner
    {
        ICloneable CloneObject(ICloneable cloneable);
    }

    public static class Cloner
    {
        public static ICloneable CloneObject(ICloneable cloneable)
        {
            var newClone = cloneable.Clone();
            return newClone;
        }
    }
}