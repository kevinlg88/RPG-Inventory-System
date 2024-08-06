using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerStatusController
{
    private readonly PlayerStatusModel _playerStatusModel;
    private readonly PlayerStatusView _playerStatusView;
    private readonly StatusEvent _statusEvent;


    public int MaxHealth => _playerStatusModel.GetMaxHealth();
    public int Resistance => _playerStatusModel.GetResistance();
    public int Attack => _playerStatusModel.GetAttack();
    public int Velocity => _playerStatusModel.GetVelocity();
    [Inject]
    public PlayerStatusController(PlayerStatusModel playerStatusModel, PlayerStatusView playerStatusView, StatusEvent statusEvent)
    {
        Debug.Log("Criou um Status Controller");
        _playerStatusModel = playerStatusModel;
        _playerStatusView = playerStatusView;
        _statusEvent = statusEvent;

        _statusEvent.OnConsumableChangeStatus += ConsumableChangeStatus;
        _statusEvent.OnGearChangeStatus += GearChangeStatus;
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


    private void ConsumableChangeStatus(ConsumableData consumableData)
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

    private void GearChangeStatus(GearData gearData)
    {
        foreach (StatusGear item in gearData.statusGears)
        {
            switch (item.enumStatus)
            {
                case EnumGear.MaxHealth:
                    _playerStatusModel.AddMaxHealth(item.value);
                    _playerStatusView.SetMaxHealth(MaxHealth);
                    break;
                case EnumGear.Resistance:
                    _playerStatusModel.AddResistance(item.value);
                    _playerStatusView.SetResistance(Resistance);
                    break;
                case EnumGear.Attack:
                    _playerStatusModel.AddAttack(item.value);
                    _playerStatusView.SetAttack(Attack);
                    break;
                case EnumGear.Velocity:
                    _playerStatusModel.AddVelocity(item.value);
                    _playerStatusView.SetVelocity(Velocity);
                    break;
                default:
                    break;
            }
        }
    }

}
