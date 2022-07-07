using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeChambre : ClickableObject,IClicked, IAction
{
    public AudioSource Son;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    public Animator Monstre1_1;
    public Animator Monstre1_2;
    public Animator Monstre2;
    public Animator Monstre3;
    public GameObject LesLampes;
    private bool On = false;


    void Awake()
    {       
        if(PlayerPrefs.GetInt("Lampe") == 0) On = false;
        else On = true;

        VerifLightState();
    }

    void VerifLightState()
    {
        //On = !On ;
        if(On) PlayerPrefs.SetInt("Lampe", 1) ;
        else PlayerPrefs.SetInt("Lampe", 0) ;


        LesLampes.SetActive(On); 

        StopAllCoroutines();

        if(On == false) // La Lampe est éteinte
        {  
            // Les monsntre son visible
         /*   Monstre1_1.gameObject.SetActive(true);
            Monstre1_2.gameObject.SetActive(true);
            Monstre2.gameObject.SetActive(true);*/
            Monstre3.gameObject.SetActive(true);

            Monstre1_1.SetTrigger("App");
            Monstre2.SetTrigger("App");
            Monstre2.SetTrigger("App");
            Monstre3.SetTrigger("App");

            StartCoroutine(WaitAndLunchAnimation1st(Monstre1_1.gameObject, Monstre1_2.gameObject, 7f));
            StartCoroutine(WaitAndLunchAnimation(Monstre2.gameObject, 5.1f));
           // StartCoroutine(WaitAndLunchAnimation(Monstre3.gameObject, 1.425f));
        }

        if(On == true) // La Lampe est allumé
        {
            Monstre1_1.gameObject.SetActive(false);
            Monstre1_2.gameObject.SetActive(false);
            Monstre2.gameObject.SetActive(false);
            Monstre3.gameObject.SetActive(false);

            // Les monsntre son caché
            Monstre1_1.SetTrigger("Disp");
            Monstre1_2.SetTrigger("Disp");
            Monstre2.SetTrigger("Disp");
            Monstre3.SetTrigger("Disp");
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



    IEnumerator WaitAndLunchAnimation1st(GameObject AnimationTarget1, GameObject AnimationTarget2, float DelayAnimation)
    {
        yield return new WaitForSeconds(Random.Range(0f,3f));
        AnimationTarget1.SetActive(true) ;
        AnimationTarget2.SetActive(true) ;

        yield return new WaitForSeconds(DelayAnimation);

        AnimationTarget1.SetActive(false) ;
        AnimationTarget2.SetActive(false) ;

        yield return new WaitForSeconds(Random.Range(0f, 3f));
        StartCoroutine(WaitAndLunchAnimation1st(AnimationTarget1, AnimationTarget2, DelayAnimation));
    }

    IEnumerator WaitAndLunchAnimation(GameObject AnimationTarget, float DelayAnimation)
    {
        yield return new WaitForSeconds(Random.Range(0f,3f));
        AnimationTarget.SetActive(true) ;
        yield return new WaitForSeconds(DelayAnimation);
        AnimationTarget.SetActive(false) ;
        yield return new WaitForSeconds(Random.Range(0f, 6f));
        StartCoroutine(WaitAndLunchAnimation(AnimationTarget, DelayAnimation));
    }
}
