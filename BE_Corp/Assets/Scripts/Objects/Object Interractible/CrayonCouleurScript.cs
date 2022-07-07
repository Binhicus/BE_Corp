using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CrayonCouleurScript : ClickableObject,IClicked, IAction
{
    public BlockReference Ques;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
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
    public void Question()
    {
        Ques.Execute();
        PlayerPrefs.SetInt("Morceau3Tableau",1);
        this.GetComponent<BoxCollider>().enabled=false;

    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            this.GetComponent<BoxCollider>().enabled=false;
        }
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() 
    { 
    }
    public void OnInspect() { }
    public void OnQuestion() { Question();}
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
}

