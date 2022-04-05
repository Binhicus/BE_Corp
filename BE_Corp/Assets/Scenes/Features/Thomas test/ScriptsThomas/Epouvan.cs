using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epouvan : MonoBehaviour, IClicked, IAction
{
    public bool Dessus;
    private bool Une;
    public GameObject ButtonChange;
    public GameObject Epouvantail;
    public GameObject PorteManteau;

    public AudioSource Son;

    private ScreenShake camShake;
    private DoorScript Door;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    private CursorController CursorManager ;


    void Awake()
    {
        CursorManager = GameObject.Find("Cursor").GetComponent<CursorController>();
        //camShake = GameObject.Find("Camera").GetComponent<ScreenShake>();
        Door = GameObject.Find("Door Leaving Room").GetComponent<DoorScript>();
        this.enabled = true;
    }


    public void OnClickAction()
    {
        CursorManager.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
        CursorManager.ActionWheelScript.TargetAction = this;
        CursorManager.ActionWheelScript.gameObject.SetActive(true);
    }

    public void Disparait()
    {
        if(Une==false)
        {
            GetComponent<BoxCollider>().enabled = false ;
            ButtonChange.SetActive(false);
            Son.Play();
            Epouvantail.GetComponent<Animator>().SetTrigger("Go");
            PorteManteau.GetComponent<Animator>().SetTrigger("Go");
            //Destroy(camShake);
            //Destroy(Door);
            Une=true;

            PlayerPrefs.SetInt("Scarecrow", 1);
            Door.OpenDoorAnimation();
        }  
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() {Debug.Log("Inspect") ;}
    public void OnQuestion() {Disparait() ;}
    
    public void OnLunchActionAfterCloseDialogue() {Disparait(); }
}
