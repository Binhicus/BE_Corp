using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ScriptDessinCuisine : ClickableObject,IClicked, IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public BlockReference questionDessin;
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

        questionDessin.Execute();
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {}
    public void OnInspect() {DisplayInspection(); }
    public void OnQuestion() {DisplayDialogue(); }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }

}

