using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{

    void Start()
    {
        Inventaire.Instance.ItemAdded += InventoryScript_ItemAdded;
        Inventaire.Instance.ItemRemoved += Inventory_ItemRemoved;
    }

    void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventaire");
        foreach(Transform slot in inventoryPanel)
        {
            //Border ... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            UIInventoryItem itemDragHandler = imageTransform.GetComponent<UIInventoryItem>();

            //On a trouvé le slot vide
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }

    void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        /*Transform inventoryPanel = transform.Find("Inventaire");
        foreach (Transform slot in inventoryPanel)
        {
            //Border ... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            UIInventoryItem itemDragHandler = imageTransform.GetComponent<UIInventoryItem>();

            //On a trouvé l'item dans l'UI
            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;

                //reference de l'item
                itemDragHandler.Item = null; //peut être susceptible à passer en commentaire

                break;
            }
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
