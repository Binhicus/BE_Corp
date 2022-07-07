using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MicroOndeScript : ClickableObject,IClicked, IAction
{
     public BlockReference remarqueClient;

    public AudioSource Son;

    private ScreenShake camShake;

    public GameObject CameraActivate ;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;


    void Awake()
    {
        if(PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            this.GetComponent<BoxCollider>().enabled=false;
        }
        
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraMicro;
    }

    private void Start() 
    {
       
    }
    public void CallMaj()
    {
        MisAJourEffect.Instance.MiseAJour();
    }

    void LookZone()
    {

        this.GetComponent<BoxCollider>().enabled=false;
        CameraActivate.SetActive(true);

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }
        
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            this.GetComponent<BoxCollider>().enabled=false;
        }
    }


    public void OnClickAction()
    {

       
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
        
        if(PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            this.GetComponent<BoxCollider>().enabled=false;
        }
        
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    void DisplayInspection()
    {
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
    }

    void DisplayDialogue()
    {
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.GetComponent<DialogueControllerScript>().TargetAction = this ;
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.GetComponent<DialogueControllerScript>().LunchActionAfterClose = true ;
       // CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
        remarqueClient.Execute();
    }

    public void DialogMicro()
    {
        

    }




    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {LookZone();}
    public void OnInspect() {DialogMicro(); }
    public void OnQuestion() {DisplayDialogue(); }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
    

}


