using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EnveloppeScript : ClickableObject,IClicked, IAction
{


    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public BlockReference DialogEnvelop;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("Séquence 1 Done") == 0)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

        DialogEnvelop.Execute();

        PlayerPrefs.SetInt("IndiceEscargot",1);
        
    }

    public void FonctionMaj()
    {
        MisAJourEffect.Instance.MiseAJour();
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() 
    {
        
    }
    public void OnInspect() { }
    public void OnQuestion() { DisplayDialogue(); }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
    

}
