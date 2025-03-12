using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject UI_Inventory;
    private bool isInventory_Open = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventory_Open = !isInventory_Open;

            if (UI_Inventory != null)
            {
                UI_Inventory.SetActive(isInventory_Open);
            }
        }
        else
        {
            if (UI_Inventory == null)
            {
                return;
            }

            // Additional logic when UI_Inventory is not null
        }

    }
}
