using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<AllItems> inventoyItems = new List<AllItems>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item)
    {
        if(!inventoyItems.Contains(item))
        {
            inventoyItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (!inventoyItems.Contains(item))
        {
            inventoyItems.Remove(item);
        }
    }

    public enum AllItems
    {
        KeyDorm,
        KeyFirstHouse
    }
}
