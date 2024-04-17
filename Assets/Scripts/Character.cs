using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public string characterName;
    public Instancer instancer;
    public InstanceData instanceData;
    [SerializeField] protected float movementSpeed;

    protected virtual void Funcion1()
    {
        Debug.Log("Funcion 1 padre");
        //Do A
    }

    protected abstract void Funcion2();
}

[Serializable]
public class Instancer
{
    public string instancerID;
}

[Serializable]
public struct InstanceData
{
    public string instanceID;
}