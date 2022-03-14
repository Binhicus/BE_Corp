using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemInventaire
{
    string Name { get; }
    Sprite Image { get; }


    void OnPickUp();

    void OnDrop();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IItemInventaire item)
    {
        Item = item;
    }

    public IItemInventaire Item;
}
