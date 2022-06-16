using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIndiceScript : ZoomableObject, IClicked, IAction
{
    //public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public GameObject CameraActivate ;

    void LookZone()
    {
        CameraActivate.SetActive(true);

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }
    }


    public void OnClickAction()
    {
        LookZone();
        /*CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);*/
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() { }
    public void OnQuestion() { }
    public void OnLook() { LookZone(); }


    public void OnLunchActionAfterCloseDialogue() { }

    public void Deb()
    {
    Debug.Log("Yes");        
    }

}
