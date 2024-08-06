using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] GameObject playerStatusViewPrefab;
    public override void InstallBindings()
    {
        //Models
        Container.Bind<InventoryModel>().AsSingle();
        Container.Bind<PlayerStatusModel>().AsSingle();
        Container.Bind<PlayerGearModel>().AsSingle();
        //Events
        Container.Bind<InventoryEvent>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<StatusEvent>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<GearEvent>().FromNewComponentOnNewGameObject().AsSingle();
        //Controllers
        Container.Bind<InventoryController>().AsSingle();
        Container.Bind<PlayerStatusController>().AsSingle();
        Container.Bind<PlayerGearController>().AsSingle();
        //Views
        Container.Bind<InventoryView>().AsSingle();
        //Container.Bind<PlayerStatusView>().FromComponentInNewPrefab(playerStatusViewPrefab).AsSingle();
        Container.Bind<PlayerStatusView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerGearView>().AsSingle();


    }
}