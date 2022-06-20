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
     private bool On;
    // Start is called before the first frame update
    void Awake()
    {       
        
         if(PlayerPrefs.GetInt("Lampe")==0)
         {
            LesLampes.SetActive(false);
             Monstre1.SetActive(true);
            Monstre2.SetActive(true);
            Monstre3.SetActive(true);
            Monstre4.SetActive(true);
            On=false;
         }

         if(PlayerPrefs.GetInt("Lampe")==1)
         {
            On=true;
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
        Debug.Log("Allume");
        //Son.Play();
        Monstre1.GetComponent<Animator>().SetTrigger("Disp");
        Monstre2.GetComponent<Animator>().SetTrigger("Disp");
        Monstre3.GetComponent<Animator>().SetTrigger("Disp");
        Monstre4.GetComponent<Animator>().SetTrigger("Disp");
        
        LesLampes.SetActive(true);
        PlayerPrefs.SetInt("Lampe",1);

        StartCoroutine(coroutineA());
    }
    public void Eteins()
    {
        Debug.Log("Eteins");
        Monstre1.SetActive(true);
        Monstre2.SetActive(true);
        Monstre3.SetActive(true);
        Monstre4.SetActive(true);
        Monstre1.GetComponent<Animator>().SetTrigger("App");
        Monstre2.GetComponent<Animator>().SetTrigger("App");
        Monstre3.GetComponent<Animator>().SetTrigger("App");
        Monstre4.GetComponent<Animator>().SetTrigger("App");
        
        LesLampes.SetActive(false);
        PlayerPrefs.SetInt("Lampe",0);

        StartCoroutine(coroutineB());
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
        if(On==true)
        {
            Eteins();
        }
        if(On==false)
        {
            Allume();
        }
    }
    public void OnInspect() { }
    public void OnQuestion() { }
    public void OnLook() {}


    public void OnLunchActionAfterCloseDialogue() { }


    IEnumerator coroutineA()
    {   
        yield return new WaitForSeconds(1.0f); 
        On=true;
    }

    IEnumerator coroutineB()
    {   
        yield return new WaitForSeconds(1.0f); 
        On=false;
    }
    

}
