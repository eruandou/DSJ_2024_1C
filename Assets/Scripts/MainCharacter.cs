using UnityEngine;

public class MainCharacter : Character
{
    protected override void Funcion1()
    {
        //Do A
        Debug.Log("Funcion 1 Hijo");
        base.Funcion1();
    }

    protected override void Funcion2()
    {
    }
}