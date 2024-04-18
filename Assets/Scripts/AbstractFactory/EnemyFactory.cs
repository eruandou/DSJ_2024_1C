namespace AbstractFactory
{
    public class EnemyFactory : AbstractFactory<Enemy>
    {
        public const string SHADOW_HEDGEHOG_ENEMY = "Shadow";
        public bool Initialized { get; private set; }
        private Enemy shadowPrefab;

        public override Enemy CreateProduct(string productCode)
        {
            if (productCode == SHADOW_HEDGEHOG_ENEMY)
            {
                return shadowPrefab;
            }

            return default;
        }

        public void Initialize(Enemy shadowPrefab)
        {
            this.shadowPrefab = shadowPrefab;
            Initialized = true;
        }
    }
}