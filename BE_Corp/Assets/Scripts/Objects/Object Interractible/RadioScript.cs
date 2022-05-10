using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RadioScript : MonoBehaviour,IClicked, IAction
{
    public BlockReference blockRef;

    public AudioSource Son;

    private ScreenShake camShake;

    public GameObject CameraActivate ;
    public GameObject TexteMeteo;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;




    void Awake()
    {
        
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraRadio;
    }

    private void Start() 
    {
        TexteMeteo=GameObject.Find("Nord meteo");
    }

    void LookZone()
    {

        if(PlayerPrefs.GetInt("Antenne")==1&&PlayerPrefs.GetInt("PileDansRadio")==1&&PlayerPrefs.GetInt("Parapluie")==0)
        {
            Debug.Log("Go");
        CameraActivate.SetActive(true);

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }

        StartCoroutine(coroutineA());
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
       // CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
        blockRef.Execute();
    }

    public void DialogRadio()
    {
        blockRef.Execute();
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(0.6f);
        TexteMeteo.GetComponent<Animator>().SetBool("Zero", false);
       
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

