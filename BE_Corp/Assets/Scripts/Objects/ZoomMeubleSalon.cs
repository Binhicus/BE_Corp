using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomMeubleSalon : ClickableObject,IClicked, IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public GameObject CameraActivate ;
    // Start is called before the first frame update
    void Start()
    {
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraMeuble;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LookZone()
    {
        CameraActivate.SetActive(true);

        this.GetComponent<BoxCollider>().enabled=false;

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }
    }

    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    void DisplayInspection()
    {
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
    }

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {}
    public void OnInspect() {LookZone(); }
    public void OnQuestion() { }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
    

}
