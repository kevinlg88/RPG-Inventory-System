using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private InventoryView inventoryViewPrefab;

    public override void InstallBindings()
    {
        Container.Bind<InventoryModel>().AsSingle();
        Container.Bind<InventoryEvent>().AsSingle();
        //Container.Bind<InventoryEvent>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<InventoryController>().AsSingle();

        // Create and bind InventoryView
        Container.Bind<InventoryView>().FromInstance(inventoryViewPrefab).AsSingle();

        // Initialize InventoryView
        Container.QueueForInject(inventoryViewPrefab);
    }
}