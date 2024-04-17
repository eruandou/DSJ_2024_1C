using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private const string OPEN_STATE = "Open";
    [SerializeField] private Animator animator;
    private bool isOpen;
    private static readonly int Open = Animator.StringToHash(OPEN_STATE);

    private void InteractDoor()
    {
        isOpen = !isOpen;
        animator.SetBool(Open, isOpen);
    }

    public string GetInteractableName()
    {
        return string.Empty;
    }

    public void Interact()
    {
        InteractDoor();
    }
}