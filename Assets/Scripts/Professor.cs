using System;
using System.Collections.Generic;
using AbstractFactory;
using Command;
using Flyweight;
using Helpers;
using Prototype;
using Strategy;
using UnityEngine;

public interface IStack<T>
{
    int Count { get; }
    void Push(T element);
    T Pop();
    T Peek();
    bool IsEmpty();
}

public class Professor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private ProfessorData data;
    [SerializeField] private EnemyCreationCommandGenerator enemyCommandGenerator;
    private IInteractable latestInteractable;
    private List<IFireWeapon> weapons;
    private IFireWeapon currentFireWeapon;
    private int currentWeaponIndex;
    private BulletInfo latestBulletInfo;

    private void Update()
    {
        MoveCharacter();
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PrintLatestInteractable();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TryDamage();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        if (!enemyCommandGenerator.TryGenerateEnemyCreationCommand(EnemyFactory.SHADOW_HEDGEHOG_ENEMY,
                RandomPosition.GetRandomPositionInLimits(), out var enemyCommand))
        {
            return;
        }

        // var enemyInstantiateCommand =
        // enemyCommandGenerator.TryGenerateEnemyCreationCommand(EnemyFactory.SHADOW_HEDGEHOG_ENEMY,
        // RandomPosition.GetRandomPositionInLimits());
        EventQueue.EventQueue.Instance.EnqueueCommand(enemyCommand);
    }

    private void Shoot()
    {
        data.instantiatedBullet = Instantiate(data.BulletPrefab);
        latestBulletInfo = new BulletInfo(10, name, "");
    }

    public BulletInfo GetLatestBulletInfoClone()
    {
        var newBulletInfoClone = Cloner.CloneObject(latestBulletInfo);
        // var castedBullet = (BulletInfo)newBulletInfoClone;
        if (newBulletInfoClone is BulletInfo castedBulletAs)
            return castedBulletAs;
        return null;
    }

    private void TryDamage()
    {
        Collider[] interactables =
            Physics.OverlapSphere(interactionPoint.position, data.InteractionRadius, data.DamageableMask);

        foreach (Collider damageable in interactables)
        {
            if (damageable.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.GetDamage(10);
            }
        }
    }

    private void ToggleWeapon()
    {
        currentWeaponIndex++;
        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }

        currentFireWeapon = weapons[currentWeaponIndex];
    }

    private void MoveCharacter()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 movementInput = new Vector3(horizontal, 0, vertical).normalized;

        var movementCommand = new MovementCommand(movementInput, data.MovementSpeed, transform, Time.deltaTime);
        EventQueue.EventQueue.Instance.EnqueueCommand(movementCommand);
    }

    private void TryInteract()
    {
        Debug.Log("Try interact");

        Collider[] interactables =
            Physics.OverlapSphere(interactionPoint.position, data.InteractionRadius, data.InteractionMask);

        foreach (Collider interactable in interactables)
        {
            if (interactable.TryGetComponent(out IInteractable interactableObject))
            {
                latestInteractable = interactableObject;
                interactableObject.Interact();
            }

            if (interactable.TryGetComponent<IAnswerer>(out var answerer))
            {
                answerer.GetAnswer();
            }
        }
    }

    private void PrintLatestInteractable()
    {
        Debug.Log(latestInteractable?.GetInteractableName());
    }
}