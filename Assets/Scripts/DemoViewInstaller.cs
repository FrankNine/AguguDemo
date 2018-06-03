using UnityEngine.UI;

using Zenject;

public class DemoViewInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.FindAndBindComponentByName<Button>("IncButton");
        Container.FindAndBindComponentByName<Button>("DecButton");
        Container.FindAndBindComponentByName<Text>("PointText");
    }
}