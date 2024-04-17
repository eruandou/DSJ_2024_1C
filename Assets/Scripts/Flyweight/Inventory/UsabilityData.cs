using UnityEngine;

[CreateAssetMenu(menuName = "Create " + nameof(UsabilityData), fileName = "UsabilityData", order = 0)]
public abstract class UsabilityData : ScriptableObject
{
    public abstract void Use();
}