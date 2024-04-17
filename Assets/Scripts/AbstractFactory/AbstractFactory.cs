using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactory
{
    public abstract class AbstractFactory<T> where T: IProduct
    {
        public abstract T CreateProduct(string productCode);
    }

    public abstract class BuyableObjectFactory
    {
        public abstract BuyableProduct CreateProduct(string productCode);
    }

    public interface IProduct
    {
    }

    public interface BuyableProduct : IProduct
    {
        float Price { get; }
    }

    public class Shoe : BuyableProduct
    {
        public float Price { get; private set; }
        public string Material { get; private set; }
        public float Size { get; private set; }

        public Shoe(string material, float size, float price)
        {
            Material = material;
            Size = size;
            Price = price;
        }
    }

    public class ShoeFactory : AbstractFactory<Shoe>
    {
        public override Shoe CreateProduct(string productCode)
        {
            return new LeatherShoe();
        }

        private class LeatherShoe : Shoe
        {
            public LeatherShoe() : base("Leather", 42f, 80f)
            {
            }
        }
    }

    public class ChairFactory : AbstractFactory<Chair>
    {
        private Dictionary<string, Chair> availableChairs = new Dictionary<string, Chair>()
        {
            { nameof(ChairMaterial.Wood), new WoodenChair() },
            { nameof(ChairMaterial.Metal), new MetalChair() },
            { nameof(ChairMaterial.Plastic), new PlasticChair() }
        };

        public override Chair CreateProduct(string productCode)
        {
            return GetChair(productCode);
        }

        public Chair GetChair(string chairMaterial)
        {
            if (availableChairs.TryGetValue(chairMaterial, out Chair newChair))
            {
                return newChair;
            }

            Debug.LogError($"Chair with material {chairMaterial.ToString()} not found");
            return default;
        }

        private class WoodenChair : Chair
        {
            internal WoodenChair() : base(
                "Wooden chair", 4f, 25f, ChairMaterial.Wood, 22f)
            {
            }
        }

        private class MetalChair : Chair
        {
            internal MetalChair() : base(
                "Metal chair", 2f, 50f, ChairMaterial.Metal, 30f)
            {
            }
        }

        private class PlasticChair : Chair
        {
            internal PlasticChair() : base(
                "Plastic chair", 6f, 15f, ChairMaterial.Plastic, 20f)
            {
            }
        }
    }

    public class Chair : IProduct
    {
        public float Price { get; private set; }
        public ChairMaterial material { get; private set; }
        public string chairName { get; private set; }
        public float flexibility { get; private set; }
        public float weight { get; private set; }

        public Chair(string chairName, float flexibility, float weight, ChairMaterial material, float price)
        {
            this.chairName = chairName;
            this.flexibility = flexibility;
            this.weight = weight;
            this.material = material;
            this.Price = price;
        }
    }

    public enum ChairMaterial
    {
        Wood,
        Metal,
        Plastic
    }

    public class Customer
    {
        public void GoShopping()
        {
            var boughtChair = new ChairFactory();
            Chair producedChair = boughtChair.GetChair(nameof(ChairMaterial.Plastic));
            Debug.Log(
                $"Got {producedChair.chairName}, " +
                $"with weight {producedChair.weight}, with flexibility " +
                $"{producedChair.flexibility} with material " +
                $"{producedChair.material.ToString()}");
        }
    }
}