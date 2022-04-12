using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdinateurScript : MonoBehaviour, IClicked, IAction
{
    private GameObject CameraActivate ;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public AlimentationScript ScriptAlimentationComputer ;

    void Awake()
    {
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraOrdi;
    }




    void LookZone()
    {
        CameraActivate.SetActive(true);        

        if(ScriptAlimentationComputer.ComputerAsBeLunch == false)
        {
            ScriptAlimentationComputer.LunchComputer();            
        }



        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }
        
    }

    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
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
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
    }



    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {LookZone();}
    public void OnInspect() {DisplayInspection(); }
    public void OnQuestion() {DisplayDialogue(); }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
}
