using Strategy;
using UnityEngine;

public class LaEsferaFlotante : MonoBehaviour, IInteractable, IAnswerer
{
    private Transform cachedTransform;
    private bool isEnlarged;
    [SerializeField] private string myAnswer;
    [SerializeField] private string myName;

    private void Awake()
    {
        cachedTransform = transform;
    }

    private void EsferaInteract()
    {
        isEnlarged = !isEnlarged;
        cachedTransform.localScale *= isEnlarged ? 0.5f : 2f;
    }

    public void GetAnswer()
    {
        Debug.Log(myAnswer);
    }

    public string GetInteractableName()
    {
        return myName;
    }

    public void Interact()
    {
        EsferaInteract();
    }
}