using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BallInteraction : MonoBehaviour, IClicked, IAction
{
    private KickBall kickBall;
    public string nomDuBallon;

    public BlockReference inspect;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();


    private void OnEnable()
    {
        kickBall = GameObject.Find(nomDuBallon).GetComponent<KickBall>();
    }
    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
        }
    }

    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }

    public void OnTake()
    {
        Debug.Log("Taken");
    }

    public void OnUse() 
    {
        kickBall.Kicked();
    }

    public void OnInspect() { inspect.Execute(); }
    public void OnQuestion() { Debug.Log("Question"); }

    public void OnLunchActionAfterCloseDialogue()
    {

    }

    public void OnLook()
    {
        Debug.Log("Observe"); 
    }
}
