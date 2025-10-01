using UnityEngine;
using System.Collections.Generic;

public class Inventory {
    public List<Transform> items;

    // Constructor initializes the items list
    public Inventory()
    {
        items = new List<Transform>();
    }

    // Adds the item to the inventory and deactivates it in the world
    public void AddToInventory(Transform t)
    {
        items.Add(t);
        t.gameObject.SetActive(false);
    }

    // Prints the inventory to the console
    public void PrintInventory()
    {
        string s = "";
        int i = 0;
        foreach (Transform t in items)
        {
            s += i + ": " + t.name + "\n";
            i++;
        }
        Debug.Log(s);
    }

    // Drops the item at index i to the specified position in the world
    public void DropItem(int i, Vector3 placeToDrop)
    {
        if (i < items.Count)
        {
            Transform myTrans = items[i];
            items.RemoveAt(i);
            myTrans.position = placeToDrop;
            myTrans.gameObject.SetActive(true);
        }
        PrintInventory();
    }
}
