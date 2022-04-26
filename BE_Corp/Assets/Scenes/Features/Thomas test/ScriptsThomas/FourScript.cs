using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FourScript : MonoBehaviour,IClicked, IAction
{

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public GameObject CameraActivate ;
    // Start is called before the first frame update
    void Awake()
    {
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraFour;
    }

    private void Start() 
    {
    }

    void LookZone()
    {
        if(PlayerPrefs.GetInt("Four")==1)
     {
            Debug.Log("Go");
        CameraActivate.SetActive(true);

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }
     }
     
     else

     {
        Debug.Log("Desole gros mais tu peux pas encore");
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
