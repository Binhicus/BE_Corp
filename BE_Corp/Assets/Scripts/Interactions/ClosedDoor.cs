using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject LeaveStep;


    public void DoItemInteraction()
    {
        Debug.Log("C'est ouvert merci beaucoup pour la participation");
        this.GetComponentInParent<Animator>().SetTrigger("Door Animation");
        LeaveStep.SetActive(true);
        LeaveStep.GetComponentInParent<BoxCollider>().enabled=true;
       // unlocked.Play();
    }

    private void Awake() {
        LeaveStep=GameObject.Find("LeaveStep");
    }
}
