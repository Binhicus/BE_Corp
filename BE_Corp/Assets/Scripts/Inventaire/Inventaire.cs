using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : Singleton<Inventaire>
{
    private const int SLOTS = 9;
    
    private List<IItemInventaire> mItems = new List<IItemInventaire>();
    
    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    protected override void Awake()
    {
        base.Awake();
    }


    public void AddItem(IItemInventaire item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                Debug.Log("Added, Count " + mItems.Count);

                item.OnPickUp();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IItemInventaire item)
    {
        Debug.Log("on remove Count " + mItems.Count);
        if (mItems.Contains(item))
        {
            Debug.Log(item);
            mItems.Remove(item);

            item.OnDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if(collider != null)
            {
                collider.enabled = true;
            }

            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}
