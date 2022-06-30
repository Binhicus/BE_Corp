using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ScarecrowScript : ClickableObject, IClicked, IAction
{
    public GameObject Epouvantail;
    //public GameObject PorteManteau;
    public BlockReference question, inspect, dissolve, maj;

    [Header("Sounds")]
    //public AudioSource ouverture;
    public AudioSource Son;


    private ScreenShake camShake;
    public DoorScript Door;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;


    void Awake()
    {
        //camShake = GameObject.Find("Camera").GetComponent<ScreenShake>();
        Door = GameObject.Find("Door Leaving Room").GetComponent<DoorScript>();
        this.enabled = true;
        if (PlayerPrefs.GetInt("Séquence 1 Done") == 0)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Start() 
    {
        VerifAnimation();
    }

    void VerifAnimation()
    {
        if(PlayerPrefs.GetInt("Scarecrow") == 0)
        {
            // Nothing
        } else {
            GetComponent<BoxCollider>().enabled = false ;
            //Epouvantail.GetComponent<Animator>().SetTrigger("disabled");
            Epouvantail.SetActive(false);

            //PorteManteau.GetComponent<Animator>().SetTrigger("CoatRack Enable");        
        }
    }



    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
        }
    }

    public void Disparait()
    {
        //maj.Execute();
        GetComponent<BoxCollider>().enabled = false ;
        Debug.Log("collider enlevé");
        Son.Play();
        Debug.Log("son joué");
        Epouvantail.GetComponent<Animator>().CrossFade("Disappear", 0.3f);
        Debug.Log("animation lancée");
        //PorteManteau.GetComponent<Animator>().SetTrigger("CoatRack Animation");
        Jauge.Instance.stadeProg += 1;
        Debug.Log("progression ++");
        MisAJourEffect.Instance.MiseAJour();

        PlayerPrefs.SetInt("Scarecrow", 1);
        Door.OpenDoorAnimation();        
        Debug.Log("porte ouverte");

        dissolve.Execute();
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
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() {inspect.Execute(); }
    public void OnQuestion() {question.Execute(); }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
    

}
