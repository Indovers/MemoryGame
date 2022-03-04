using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private CardMatchChecker cardMatchChecker;

    public override void InstallBindings()
    {
        BindCardMatchChecker();
    }

    private void BindCardMatchChecker()
    {
        Container
            .Bind<CardMatchChecker>()
            .FromInstance(cardMatchChecker)
            .AsSingle()
            .NonLazy();
    }
}
