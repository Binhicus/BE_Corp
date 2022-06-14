using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
using Fungus;

public class Table : ClickableObject, IClicked, IAction
{
    private ZoomIndiceScript ZoomOnTable ;

    public BlockReference admettre;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();


    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }

    private void Awake() 
    {
        ZoomOnTable = GetComponent<ZoomIndiceScript>();

        if(PlayerPrefs.GetInt("Chaise") == 0)
        {
            CanZoom(false) ;
        } else {
            CanZoom(true);
        }

    }

    public void CanZoom(bool Can)
    {
        ZoomOnTable.enabled = Can ;        

        if(Can) Destroy(this) ;
    }

    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            if(PlayerPrefs.GetInt("Chaise") == 0)
            {
                CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
                CursorController.Instance.ActionWheelScript.TargetAction = this;
                CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
            }
        }
    }

    public void OnClose() {}
    public void OnInspect() {}
    public void OnLook() {}
    public void OnLunchActionAfterCloseDialogue() {}
    public void OnOpen() {}

    public void OnQuestion()
    {
        admettre.Execute();
        PlayerPrefs.SetInt("Avoue Table", 1);
    }

    public void OnTake() {}
    public void OnUse() {}

}
