using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private InventoryView inventoryViewPrefab;

    public override void InstallBindings()
    {
        Debug.Log("Instaling bind single");
        Container.Bind<InventoryModel>().AsSingle();
        Container.Bind<InventoryEvent>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<InventoryController>().AsSingle();
        // Container.Bind<InventoryView>().AsSingle();
        Container.Bind<InventoryView>().AsTransient();

    }
}