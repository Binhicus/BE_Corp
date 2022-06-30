using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FourScript : ClickableObject,IClicked, IAction
{

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;

    public List<ActionWheelChoiceData> ListInteractPossible2 = new List<ActionWheelChoiceData>() ;

    public List<ActionWheelChoiceData> ListInteractPossible3 = new List<ActionWheelChoiceData>() ;

    public GameObject CameraActivate ;

    public BlockReference questionsmoke;

    
    // Start is called before the first frame update
    void Awake()
    {
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraFour;
        Debug.Log(PlayerPrefs.GetInt("Smoke"));

        if(PlayerPrefs.GetInt("Smoke")==4)
        {
             this.GetComponent<BoxCollider>().enabled=false;
        }
    }

    private void Update() {
         
    }

    private void Start() 
    {
        
    }

    void LookZone()
    {
        if(PlayerPrefs.GetInt("Four")==1&&PlayerPrefs.GetInt("Smoke")!=2)
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
        if(PlayerPrefs.GetInt("Four")==0)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
        }
        if(PlayerPrefs.GetInt("Four")==1)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible2 ;
        }
        if(PlayerPrefs.GetInt("FourOk")==2)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible3 ;
        }
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
        
    }

    public void ApresCramax()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible3;
    }

    void DisplayInspection()
    {
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
    }

    void DisplayDialogue()
    {
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.GetComponent<DialogueControllerScript>().TargetAction = this ;
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.GetComponent<DialogueControllerScript>().LunchActionAfterClose = true ;

        if(PlayerPrefs.GetInt("Smoke")==2)
        {
            questionsmoke.Execute();
            Debug.Log("ba lance");
            StartCoroutine(coroutineA());
        }
    }

    public void CallMajFour()
    {
        MisAJourEffect.Instance.TableauUpdated();
    }

    IEnumerator coroutineA()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerPrefs.SetInt("Morceau2Tableau",1);
        PlayerPrefs.SetInt("Smoke",4);
        PlayerPrefs.SetInt("FourOk",2);
        this.GetComponent<BoxCollider>().enabled=false;
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
