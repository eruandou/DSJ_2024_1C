using System.Collections.Generic;
using UnityEngine;

namespace Flyweight.Type
{
    [CreateAssetMenu(menuName = "Data/Type", fileName = "NewType")]
    public class TypeData : ScriptableObject
    {
        [SerializeField] private string frontFacingName;

        [SerializeField] private List<GenerationData> compatibleGenerationData;

        public bool IsCompatibleWithGeneration(GenerationData generation)
        {
            return compatibleGenerationData.Contains(generation);
        }
    }
}