using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerStatusController
{
    private readonly PlayerStatusModel _playerStatusModel;
    private PlayerStatusView _playerStatusView;
    private readonly StatusEvent _statusEvent;


    public int MaxHealth => _playerStatusModel.GetMaxHealth();
    public int Resistance => _playerStatusModel.GetResistance();
    public int Attack => _playerStatusModel.GetAttack();
    public int Velocity => _playerStatusModel.GetVelocity();
    [Inject]
    private void Initialize(PlayerStatusView playerStatusView)
    {
        _playerStatusView = playerStatusView;
    }
    [Inject]
    public PlayerStatusController(PlayerStatusModel playerStatusModel, StatusEvent statusEvent)
    {
        _playerStatusModel = playerStatusModel;
        _statusEvent = statusEvent;

        _statusEvent.OnConsumableGainStatus += ConsumableGainStatus;
        _statusEvent.OnGearEquipStatus += GearEquipStatus;
        _statusEvent.OnGearRemovedStatus += GearRemovedStatus;
    }

    public void SetMaxHealth(int maxHealth)
    {
        _playerStatusModel.AddMaxHealth(maxHealth);
    }

    public void SetResistance(int resistance)
    {
        _playerStatusModel.AddResistance(resistance);
    }

    public void SetAttack(int attack)
    {
        _playerStatusModel.AddAttack(attack);
    }

    public void SetVelocity(int velocity)
    {
        _playerStatusModel.AddVelocity(velocity);
    }


    private void ConsumableGainStatus(ConsumableData consumableData)
    {
        foreach (StatusConsumable item in consumableData.status)
        {
            switch (item.enumStatus)
            {
                case EnumConsumable.RestoreHealth:
                    _playerStatusModel.AddMaxHealth(item.value);
                    _playerStatusView.SetMaxHealth(MaxHealth);
                    break;
                case EnumConsumable.IncreaseDefense:
                    _playerStatusModel.AddResistance(item.value);
                    _playerStatusView.SetResistance(Resistance);
                    break;
                case EnumConsumable.IncreaseAttack:
                    _playerStatusModel.AddAttack(item.value);
                    _playerStatusView.SetAttack(Attack);
                    break;
                default:
                    break;
            }
        }
    }

    private void GearEquipStatus(GearData gearData)
    {
        foreach (StatusGear item in gearData.statusGears)
        {
            switch (item.enumStatus)
            {
                case EnumGearStatus.MaxHealth:
                    _playerStatusModel.AddMaxHealth(item.value);
                    _playerStatusView.SetMaxHealth(MaxHealth);
                    break;
                case EnumGearStatus.Resistance:
                    _playerStatusModel.AddResistance(item.value);
                    _playerStatusView.SetResistance(Resistance);
                    break;
                case EnumGearStatus.Attack:
                    _playerStatusModel.AddAttack(item.value);
                    _playerStatusView.SetAttack(Attack);
                    break;
                case EnumGearStatus.Velocity:
                    _playerStatusModel.AddVelocity(item.value);
                    _playerStatusView.SetVelocity(Velocity);
                    break;
                default:
                    break;
            }
        }
    }

    private void GearRemovedStatus(GearData gearData)
    {
        foreach (StatusGear item in gearData.statusGears)
        {
            switch (item.enumStatus)
            {
                case EnumGearStatus.MaxHealth:
                    _playerStatusModel.RemoveMaxHealth(item.value);
                    _playerStatusView.SetMaxHealth(MaxHealth);
                    break;
                case EnumGearStatus.Resistance:
                    _playerStatusModel.RemoveResistance(item.value);
                    _playerStatusView.SetResistance(Resistance);
                    break;
                case EnumGearStatus.Attack:
                    _playerStatusModel.RemoveAttack(item.value);
                    _playerStatusView.SetAttack(Attack);
                    break;
                case EnumGearStatus.Velocity:
                    _playerStatusModel.RemoveVelocity(item.value);
                    _playerStatusView.SetVelocity(Velocity);
                    break;
                default:
                    break;
            }
        }
    }

}
