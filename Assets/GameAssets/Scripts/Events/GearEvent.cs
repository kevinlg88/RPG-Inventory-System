using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearEvent : MonoBehaviour
{
    public event Action<GearData> OnGearEquiped;
    public event Action<GearData> OnGearReplaced;

    public void GearEquiped(GearData gearData)
    {
        OnGearEquiped?.Invoke(gearData);
    }

    public void GearReplaced(GearData gearData)
    {
        Debug.Log("Gear Event Trigger Replace Item");
        OnGearReplaced?.Invoke(gearData);
    }
}
