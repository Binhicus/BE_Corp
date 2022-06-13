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
    // Start is called before the first frame update
    void Awake()
    {       
        
         if(PlayerPrefs.GetInt("Lampe")==0)
         {
            LesLampes.SetActive(false);
         }

         if(PlayerPrefs.GetInt("Lampe")==1)
         {
            LesLampes.SetActive(true);
            Monstre1.SetActive(false);
            Monstre2.SetActive(false);
            Monstre3.SetActive(false);
            Monstre4.SetActive(false);
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
    public void Allume()
    {
        //Son.Play();
        Monstre1.GetComponent<Animator>().SetTrigger("Disp");
        Monstre2.GetComponent<Animator>().SetTrigger("Disp");
        Monstre3.GetComponent<Animator>().SetTrigger("Disp");
        Monstre4.GetComponent<Animator>().SetTrigger("Disp");
        
        LesLampes.SetActive(true);
        PlayerPrefs.SetInt("Lampe",1);
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
        Debug.Log("ok");
    Allume();
    }
    public void OnInspect() { }
    public void OnQuestion() { }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }
    

}
