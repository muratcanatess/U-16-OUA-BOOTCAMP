using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems itemType;

    public void GetKey()
    {
        InventoryManager.Instance.AddItem(itemType);
    }
}
