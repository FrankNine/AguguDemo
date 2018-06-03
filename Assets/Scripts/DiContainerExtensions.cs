using UnityEngine;
using Zenject;

public static class DiContainerExtensions
{
    public static void FindAndBindComponentByName<T>
    (
        this DiContainer container,
        string           name,
        bool             includeInactive = false
    ) where T : Component
    {
        container.Bind<T>()
            .WithId(name)
            .FromComponentInChildren(button => button.gameObject.name == name, includeInactive: includeInactive)
            .AsSingle(name);
    }
}