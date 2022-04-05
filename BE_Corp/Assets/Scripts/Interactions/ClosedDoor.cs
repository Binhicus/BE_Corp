using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;


    public void DoItemInteraction()
    {
        Debug.Log("C'est ouvert merci beaucoup pour la participation");
       // unlocked.Play();
    }
}
