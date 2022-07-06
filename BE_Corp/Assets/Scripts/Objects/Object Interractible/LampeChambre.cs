using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeChambre : ClickableObject,IClicked, IAction
{
    public AudioSource Son;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    public GameObject Monstre1;
    public GameObject Monstre2;
    public GameObject Monstre3;
    public GameObject Monstre4;
    public GameObject LesLampes;
    private bool On = false;


    void Awake()
    {       
        if(PlayerPrefs.GetInt("Lampe")==0)    On = false;
        else    On=true;

        VerifLightState();
    }

    void VerifLightState()
    {
        //On = !On ;
        if(On) PlayerPrefs.SetInt("Lampe", 1) ;
        else PlayerPrefs.SetInt("Lampe", 0) ;


        LesLampes.SetActive(On); 

        if(On == false) // La Lampe est éteinte
        {  
            // Les monsntre son visible
            Monstre1.SetActive(true);
            Monstre2.SetActive(true);
            Monstre3.SetActive(true);
            Monstre4.SetActive(true);

            Monstre1.GetComponent<Animator>().SetTrigger("App");
            Monstre2.GetComponent<Animator>().SetTrigger("App");
            Monstre3.GetComponent<Animator>().SetTrigger("App");
            Monstre4.GetComponent<Animator>().SetTrigger("App");
        }

        if(On == true) // La Lampe est allumé
        {
            Monstre1.SetActive(false);
            Monstre2.SetActive(false);
            Monstre3.SetActive(false);
            Monstre4.SetActive(false);

            // Les monsntre son caché
            Monstre1.GetComponent<Animator>().SetTrigger("Disp");
            Monstre2.GetComponent<Animator>().SetTrigger("Disp");
            Monstre3.GetComponent<Animator>().SetTrigger("Disp");
            Monstre4.GetComponent<Animator>().SetTrigger("Disp");
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
    public void OnUse()  
    {
        On = !On ;
        VerifLightState();
    }
    public void OnInspect() { }
    public void OnQuestion() { }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }

}
