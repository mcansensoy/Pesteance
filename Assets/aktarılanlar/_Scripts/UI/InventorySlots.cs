using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;

    public WeaponInfo Get_WeaponInfo()
    {
        return _weaponInfo;
    }
}
