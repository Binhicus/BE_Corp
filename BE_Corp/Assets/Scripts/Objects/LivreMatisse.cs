using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LivreMatisse : ClickableObject,IClicked, IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public BlockReference DialogMatisse;
    // Start is called before the first frame update
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
    }

    public void Parle()
    {
        DialogMatisse.Execute();  PlayerPrefs.SetInt("Matisse",1);
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() 
    { 
    }
    public void OnInspect() { Parle();}
    public void OnQuestion() { }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
}

