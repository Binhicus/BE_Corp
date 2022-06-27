using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum Scene { Menu, Game }
public class HUD : MonoBehaviour
{
    public GameObject DezoomButton ;
    public Scene scene;
    public AudioSource pickUpSound;

    void Start()
    {
        if(scene == Scene.Game)
        {
            Inventaire.Instance.ItemAdded += InventoryScript_ItemAdded;
            Inventaire.Instance.ItemRemoved += Inventory_ItemRemoved;
        }

    }

    void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        pickUpSound.Play();
        Transform inventoryPanel = GameObject.Find("Inventaire").transform;
        foreach(Transform slot in inventoryPanel)
        {
            //Border ... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            slot.GetChild(0).GetComponent<Image>().enabled=true;
            //Instantiate(e.Item.visual, slot.GetChild(0).transform.GetChild(0).transform);
            UIInventoryItem itemDragHandler = imageTransform.GetComponent<UIInventoryItem>();
             


            //On a trouvé le slot vide
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                imageTransform.GetComponent<UIInventoryItem>().objectID = e.Item.Name;
                Instantiate(e.Item.visual, image.gameObject.transform);


                break;
            }
        }
    }

    void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
       /* Transform inventoryPanel = transform.Find("Inventaire");
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

    private void Update() 
    {
        if(GameObject.FindGameObjectWithTag("Camera Zoom") != null) DezoomButton.SetActive(true);

    }

    public void DezoomCamera()
    {
        if(GameObject.FindGameObjectWithTag("Camera Zoom") != null)
        {
            GameObject.FindGameObjectWithTag("Camera Zoom").SetActive(false);
            DezoomButton.SetActive(false);
        }

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = true ;
        }
    }
}
