using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gear", menuName = "Inventory/Gear")]
public class GearData : ItemData
{
    [SerializeField]
    public List<StatusGear> statusGears;

}

[Serializable]
public class StatusGear
{
    public EnumGear enumStatus;
    public int value;
}

[Serializable]
public enum EnumGear
{
    None,
    MaxHealth,
    Resistance,
    Attack,
    Velocity
}
