using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowScript : MonoBehaviour, IClicked, IAction
{
    public GameObject Epouvantail;
    public GameObject PorteManteau;

    public AudioSource Son;

    private ScreenShake camShake;
    private DoorScript Door;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;


    void Awake()
    {
        //camShake = GameObject.Find("Camera").GetComponent<ScreenShake>();
        Door = GameObject.Find("Door Leaving Room").GetComponent<DoorScript>();
        this.enabled = true;
    }

    private void Start() 
    {
        VerifAnimation();
    }

    void VerifAnimation()
    {
        if(PlayerPrefs.GetInt("Scarecrow") == 0)
        {
            // Nothing
        } else {
            GetComponent<BoxCollider>().enabled = false ;
            Epouvantail.GetComponent<Animator>().SetTrigger("Scarecrow Disable");
            PorteManteau.GetComponent<Animator>().SetTrigger("CoatRack Enable");        
        }
    }



    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    public void Disparait()
    {
        GetComponent<BoxCollider>().enabled = false ;
        Son.Play();
        Epouvantail.GetComponent<Animator>().SetTrigger("Scarecrow Animation");
        PorteManteau.GetComponent<Animator>().SetTrigger("CoatRack Animation");


        PlayerPrefs.SetInt("Scarecrow", 1);
        Door.OpenDoorAnimation();
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() {Debug.Log("Inspect") ;}
    public void OnQuestion() {Disparait() ;}
    

}
