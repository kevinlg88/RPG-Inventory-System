using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Instaling bind as single");
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
        //Container.Bind<PlayerStatusView>().AsSingle();
        Container.Bind<PlayerGearView>().AsSingle();


    }
}