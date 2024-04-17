using UnityEngine;

[CreateAssetMenu(menuName = "Create " + nameof(HealUsability), fileName = "HealUsability", order = 0)]
public class HealUsability : UsabilityData
{
    [SerializeField] private float healAmount;
    private Professor professor;

    public override void Use()
    {
        
    }
}