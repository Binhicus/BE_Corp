using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TableauCuisineScript : ClickableObject, IClicked, IAction
{
    public BlockReference inspect1,inspect2;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();


    // Start is called before the first frame update
    void Awake()
    {
    
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

    public void Question()
    {
        if(PlayerPrefs.GetInt("Tableau1")==0)
        {
            inspect1.Execute();
            PlayerPrefs.SetInt("Tableau2",1);
        }
        if(PlayerPrefs.GetInt("Tableau1")==1)
        {
            inspect2.Execute();
            PlayerPrefs.SetInt("Tableau2",1);
            MisAJourEffect.Instance.MiseAJour();
        }
        
    }


    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }

    public void OnTake()
    {
        
    }

    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() {; Question(); }
    public void OnQuestion() {  }

    public void OnLunchActionAfterCloseDialogue() {}

    public void OnLook() { }

    public void OnDrop() {}

    public void OnPickUp()
    {
    }
}
