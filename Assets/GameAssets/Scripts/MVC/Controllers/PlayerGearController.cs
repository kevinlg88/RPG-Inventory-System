using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerGearController
{
    private PlayerGearView _playerGearView;
    private PlayerGearModel _playerGearModel;
    private GearEvent _gearEvent;

    public GearData Helmet => _playerGearModel.GetHelmet();
    public GearData TopArmor => _playerGearModel.GetTopArmor();
    public GearData Weapon => _playerGearModel.GetWeapon();
    public GearData Boots => _playerGearModel.GetBoots();
    [Inject]
    private void Initialize(PlayerGearView playerGearView)
    {
        _playerGearView = playerGearView;
    }
    [Inject]
    public PlayerGearController(PlayerGearModel playerGearModel, GearEvent gearEvent)
    {
        Debug.Log("Criou um Gear Controller");
        _playerGearModel = playerGearModel;
        _gearEvent = gearEvent;

        _gearEvent.OnGearEquiped += GearEquiped;

    }

    private void GearEquiped(GearData gearData)
    {
        if(gearData.enumGearSlot is EnumGearSlot.helmet)
        {
            if(Helmet is not null)
            {
                Debug.Log("Gear Controller gear equiped: " + Helmet.name);
                Debug.Log(" not null model");
                _gearEvent.GearReplaced(Helmet);
            }
            _playerGearModel.EquipHelmet(gearData);
            _playerGearView.EquipHelmet(gearData);
        }
        else if(gearData.enumGearSlot is EnumGearSlot.topArmor)
        {
            if(TopArmor is not null)
            {
                _gearEvent.GearReplaced(TopArmor);
            }
            _playerGearModel.EquipTopArmor(gearData);
            _playerGearView.EquipTopArmor(gearData);
        }
        else if(gearData.enumGearSlot is EnumGearSlot.weapon)
        {
            if(Weapon is not null)
            {
                _gearEvent.GearReplaced(Weapon);
            }
            _playerGearModel.EquipWeapon(gearData);
            _playerGearView.EquipWeapon(gearData);
        }
        else if(gearData.enumGearSlot is EnumGearSlot.boots)
        {
            if(Boots is not null)
            {
                _gearEvent.GearReplaced(Boots);
            }
            _playerGearModel.EquipBoots(gearData);
            _playerGearView.EquipBoots(gearData);
        }
    }
}
