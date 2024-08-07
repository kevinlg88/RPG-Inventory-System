using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEvent : MonoBehaviour
{
    public event Action<ConsumableData> OnConsumableGainStatus;

    public event Action<GearData> OnGearEquipStatus;

    public event Action<GearData> OnGearRemovedStatus;

    public void ConsumableChangeStatus(ConsumableData consumableData)
    {
        OnConsumableGainStatus?.Invoke(consumableData);
    }

    public void GearChangeStatus(GearData gearData)
    {
        OnGearEquipStatus?.Invoke(gearData);
    }

    public void GearRemoveStatus(GearData gearData)
    {
        OnGearRemovedStatus?.Invoke(gearData);
    }
}
