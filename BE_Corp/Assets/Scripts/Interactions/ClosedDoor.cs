using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;


    public void DoItemInteraction()
    {
        Debug.Log("C'est ouvert merci beaucoup pour la participation");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
