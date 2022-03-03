using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindGameSettings();
    }

    private void BindGameSettings()
    {
        Container
            .Bind<GameSettings>()
            .AsSingle()
            .NonLazy();
    }
}
