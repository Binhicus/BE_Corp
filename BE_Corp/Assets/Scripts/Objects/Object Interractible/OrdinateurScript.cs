using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrdinateurScript : ClickableObject, IClicked, IAction
{
    private GameObject CameraActivate ;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public AlimentationScript ScriptAlimentationComputer ;
    
    public List<GameObject> Postit = new List<GameObject>();

    void Awake()
    {
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraOrdi;

        VerifIndiceDisponible();
    }

    void VerifIndiceDisponible()
    {
        if(PlayerPrefs.GetInt("MdpOk") == 0)
        {
            if(PlayerPrefs.GetInt("IndiceEscargot") == 1)    Postit[1].SetActive(true);
            if(PlayerPrefs.GetInt("NordMeteo") == 1)    Postit[3].SetActive(true);
            if(PlayerPrefs.GetInt("Matisse") == 1)    Postit[2].SetActive(true);
            if(PlayerPrefs.GetInt("Tableau1") == 1 && PlayerPrefs.GetInt("Tableau2") == 1)    Postit[4].SetActive(true);
        } else {
            for (int i = 0; i < Postit.Count; i++)
            {
                if(i == 4) Postit[i].SetActive(true);
                else Postit[i].SetActive(false);
            }
        }

    }

    void LookZone()
    {
        VerifIndiceDisponible();
        Postit[0].transform.parent.GetComponent<CanvasGroup>().DOFade(1f, 1f);

        CameraActivate.SetActive(true);        

        if(ScriptAlimentationComputer.ComputerAsBeLunch == false)
        {
            ScriptAlimentationComputer.LunchComputer();            
        }


        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
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
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
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
