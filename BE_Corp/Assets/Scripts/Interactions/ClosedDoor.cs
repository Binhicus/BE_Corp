using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IHasItemInteraction
{
    public string nomItem;
    private Animator DoorAnimator;
    private string LeaveStepName;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject LeaveStep;

    bool DoorIsOpen;

    void Awake()
    {
        //DoorAnimator = this.transform.parent.GetComponent<Animator>();
        //if (GameObject.Find(LeaveStepName) != null) LeaveStep = GameObject.Find(LeaveStepName);
        LeaveStep=GameObject.Find("LeaveStep");
    }
    /*void OnEnable()
    {
        if (PlayerPrefs.GetInt("Porte Ouverte") == 0)
        {
            LeaveStep.GetComponent<DynamicLoad>().DispStep(false);
        }
        else
        {
            LeaveStep.GetComponent<DynamicLoad>().DispStep(true);
            //DoorIsOpen = true;
            DoorAnimator.SetTrigger("Open");
        }
    }*/
    public void DoItemInteraction()
    {
        Debug.Log("C'est ouvert merci beaucoup pour la participation");
        PorteOuverte();
        PasActifs();
        this.GetComponent<BoxCollider>().enabled = false;
       // unlocked.Play();
    }

    void PasActifs()
    {
        LeaveStep.SetActive(true);
        LeaveStep.GetComponentInParent<BoxCollider>().enabled = true;
    }

    void PorteOuverte()
    {
        this.GetComponentInParent<Animator>().SetTrigger("Door Animation");
        PlayerPrefs.SetInt("Porte Ouverte", 1);
    }
}
