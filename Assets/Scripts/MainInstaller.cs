using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DemoView>().FromComponentInHierarchy();
        Container.Bind<DemoViewModel>().AsSingle();
        Container.Bind<DemoPresenter>().AsSingle();
        Container.Bind<IInitializable>().To<DemoPresenter>().AsSingle();
        Container.DeclareSignal<IncreaseRequestedSignal>();
        Container.DeclareSignal<DecreaseRequestedSignal>();
    }
}