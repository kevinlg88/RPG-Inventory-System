using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEvent : MonoBehaviour
{
    public event Action<ConsumableData> OnConsumableChangeStatus;

    public event Action<GearData> OnGearChangeStatus;

    public void ConsumableChangeStatus(ConsumableData consumableData)
    {
        OnConsumableChangeStatus?.Invoke(consumableData);
    }

    public void GearChangeStatus(GearData gearData)
    {
        OnGearChangeStatus?.Invoke(gearData);
    }
}
