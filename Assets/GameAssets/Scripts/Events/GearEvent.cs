using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearEvent : MonoBehaviour
{
    public event Action<GearData> OnGearEquiped;

    public void GearEquiped(GearData gearData)
    {
        OnGearEquiped?.Invoke(gearData);
    }
}
