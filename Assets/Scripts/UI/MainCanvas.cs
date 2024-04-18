using AbstractFactory;
using Flyweight;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Button instantiateEnemiesButton;
    [SerializeField] private Button undoLatest;
    [SerializeField] private EnemyCreationCommandGenerator enemyCommandGenerator;

    private void Awake()
    {
        instantiateEnemiesButton.onClick.AddListener(InstantiateEnemies);
        undoLatest.onClick.AddListener(UndoLatestCommand);
    }

    private void UndoLatestCommand()
    {
        EventQueue.EventQueue.Instance.UndoLatest();
    }

    private void InstantiateEnemies()
    {
        //Instanciar enemigos
        if (!enemyCommandGenerator.TryGenerateEnemyCreationCommand(EnemyFactory.SHADOW_HEDGEHOG_ENEMY,
                RandomPosition.GetRandomPositionInLimits(), out var enemyCommand))
        {
            return;
        }

        EventQueue.EventQueue.Instance.EnqueueCommand(enemyCommand);
    }
}