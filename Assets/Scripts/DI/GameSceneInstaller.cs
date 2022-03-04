using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private CardMatchChecker cardMatchChecker;
    [SerializeField] private GameState gameState;

    public override void InstallBindings()
    {
        BindCardMatchChecker();
        BindGameState();
    }

    private void BindCardMatchChecker()
    {
        Container
            .Bind<CardMatchChecker>()
            .FromInstance(cardMatchChecker)
            .AsSingle()
            .NonLazy();
    }

    private void BindGameState()
    {
        Container
            .Bind<GameState>()
            .FromInstance(gameState)
            .AsSingle()
            .NonLazy();
    }
}
