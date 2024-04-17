using System;
using System.Collections.Generic;
using State.Enemy;
using UnityEngine;

//PARADIGMAS DE PROGRAMACION

public enum EnemyStates
{
    Idle,
    Patrol,
    Pursuit,
    Death
}

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyData data;
    private int currentHealth;

    [SerializeField] private Transform[] patrolPoints;
    private int patrolPointIndex = 0;

    private EnemyState currentState;
    private float elapsedTimeIdle;
    private Collider[] nearPlayers = new Collider[2];
    private Professor currentlyPursuitedPlayer;
    private List<EnemyState> enemyStates;
    private EnemyStateMachine stateMachine;

    private void Awake()
    {
        currentHealth = data.MaxHealth;

        var idleState = new EnemyIdleState(data.IdleWaitTime, GetIsPlayerNear);
        var deathState = new EnemyDeathState();
        var pursuitState = new EnemyPursuitState(transform, data.Speed, GetIsPlayerNear, GetNearestPlayer);
        var patrolState = new EnemyPatrolState(patrolPoints, transform, data.Speed, data.ThresholdToPatrolPoint,
            GetIsPlayerNear);

        enemyStates.Add(idleState);
        enemyStates.Add(deathState);
        enemyStates.Add(pursuitState);
        enemyStates.Add(patrolState);

        currentState = idleState;

        SubscribeToStateChange();
    }

    public void GetDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        // stateMachine.ExecuteState();
        currentState.OnExecute(deltaTime);
    }

    private Professor GetNearestPlayer()
    {
        int foundPlayerCount =
            Physics.OverlapSphereNonAlloc(transform.position, data.NearestPlayerCheckRadius, nearPlayers,
                data.PlayerLayer);

        if (foundPlayerCount < 1)
        {
            currentlyPursuitedPlayer = null;
            return null;
        }

        for (int i = 0; i < foundPlayerCount; i++)
        {
            var currentPlayer = nearPlayers[i];
            var currentProfessor = currentPlayer.GetComponent<Professor>();
            if (currentProfessor != null)
            {
                return currentProfessor;
            }
        }

        return null;
    }

    private bool GetIsPlayerNear()
    {
        int foundPlayerCount =
            Physics.OverlapSphereNonAlloc(transform.position, data.PlayerCheckRadius, nearPlayers, data.PlayerLayer);

        if (foundPlayerCount < 1)
        {
            currentlyPursuitedPlayer = null;
            return false;
        }

        for (int i = 0; i < foundPlayerCount; i++)
        {
            var currentPlayer = nearPlayers[i];
            var currentProfessor = currentPlayer.GetComponent<Professor>();
            if (currentProfessor != null)
            {
                return true;
            }
        }

        return false;
    }

    private void OnDestroy()
    {
        UnsubscribeToStateChanges();
    }

    private void SubscribeToStateChange()
    {
        foreach (var state in enemyStates)
        {
            state.OnStateChangePetition += HandleStateChange;
        }
    }

    private void UnsubscribeToStateChanges()
    {
        foreach (var state in enemyStates)
        {
            state.OnStateChangePetition -= HandleStateChange;
        }
    }

    private void HandleStateChange(EnemyStates p_obj)
    {
        EnemyState newState;
        switch (p_obj)
        {
            case EnemyStates.Idle:
                if (!TryGetState<EnemyIdleState>(out newState))
                {
                    throw new Exception($"State {p_obj.ToString()} not found");
                }

                break;
            case EnemyStates.Patrol:
                if (!TryGetState<EnemyPatrolState>(out newState))
                {
                    throw new Exception($"State {p_obj.ToString()} not found");
                }

                break;
            case EnemyStates.Pursuit:
                if (!TryGetState<EnemyPursuitState>(out newState))
                {
                    throw new Exception($"State {p_obj.ToString()} not found");
                }

                break;
            case EnemyStates.Death:
                if (!TryGetState<EnemyDeathState>(out newState))
                {
                    throw new Exception($"State {p_obj.ToString()} not found");
                }

                break;
            default:
                throw new Exception($"Invalid state {p_obj.ToString()}");
        }

        SetNewState(newState);
    }

    private bool TryGetState<T>(out EnemyState newState) where T : EnemyState
    {
        for (int i = 0; i < enemyStates.Count; i++)
        {
            var state = enemyStates[i];
            if (state is T enemyState)
            {
                newState = enemyState;
                return true;
            }
        }

        newState = default;
        return false;
    }

    private void SetNewState(EnemyState newState)
    {
        currentState?.OnExitState();
        currentState = newState;
        currentState.OnEnterState();
    }
}

public interface IDamageable
{
    void GetDamage(int damageAmount);
}