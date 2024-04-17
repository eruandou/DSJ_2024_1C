using System.Collections.Generic;
using UnityEngine;

namespace Flyweight.Type
{
    [CreateAssetMenu(fileName = "NewWeaknessTableData", menuName = "Data/Weakness/TableData", order = 0)]
    public class WeaknessTableData : ScriptableObject
    {
        [SerializeField] private List<TypeData> weaknesses;
        [SerializeField] private List<TypeData> resistances;
        [SerializeField] private List<TypeData> immunities;
    }

    public enum Types
    {
        Chispita,
        Normal,
        Water,
        Fire,
        Grass,
        Metal,
    }
}