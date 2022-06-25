using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TableauFinalScript : ClickableObject, IClicked, IAction
{

    public BlockReference inspect0,inspect1,inspect2,inspect3;
    public List<ActionWheelChoiceData> ListInteractPossible1 = new List<ActionWheelChoiceData>();
    public List<ActionWheelChoiceData> ListInteractPossible2 = new List<ActionWheelChoiceData>();
     public List<ActionWheelChoiceData> ListInteractPossible3 = new List<ActionWheelChoiceData>();
    public List<ActionWheelChoiceData> ListInteractPossible4 = new List<ActionWheelChoiceData>();
    public GameObject Morceau1,Morceau2,Morceau3;
    // Start is called before the first frame update
    public void OnClickAction()
    {

        if(PlayerPrefs.GetInt("Morceau1Tableau")==0&&PlayerPrefs.GetInt("Morceau2Tableau")==0&&PlayerPrefs.GetInt("Morceau3Tableau")==0&&PlayerPrefs.GetInt("PrendreFin")==0)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible1 ;
        }
        if(PlayerPrefs.GetInt("Morceau1Tableau")==1&&PlayerPrefs.GetInt("PrendreFin")==0)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible2 ;
        }

        if(PlayerPrefs.GetInt("Morceau1Tableau")==1&&PlayerPrefs.GetInt("Morceau2Tableau")==1&&PlayerPrefs.GetInt("Morceau3Tableau")==1&&PlayerPrefs.GetInt("PrendreFin")==0)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible3 ;
        }
        if(PlayerPrefs.GetInt("PrendreFin")==1)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible4 ;
        }

        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    void DisplayInspection()
    {
        CursorController.Instance.ActionWheelScript.DialogueDisplayer.SetActive(true);
    }

    void Start()
    {
        PlayerPrefs.SetInt("Morceau1Tableau",1);
        PlayerPrefs.SetInt("Morceau2Tableau",1);
        PlayerPrefs.SetInt("Morceau3Tableau",1);


        if(PlayerPrefs.GetInt("Morceau1Tableau1")==1)
        {
            Morceau1.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Morceau2Tableau")==1)
        {
            Morceau2.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            Morceau3.SetActive(true);
        }
    }

    void OnEnable()
    {
        if(PlayerPrefs.GetInt("Morceau1Tableau")==1)
        {
            Morceau1.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Morceau2Tableau")==1)
        {
            Morceau2.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            Morceau3.SetActive(true);
        }
    }
    public void Observer()
    {
        /*if(PlayerPrefs.GetInt("Morceau1Tableau")==0&&PlayerPrefs.GetInt("Morceau2Tableau")==0&&PlayerPrefs.GetInt("Morceau3Tableau")==0)
        {
            inspect0.Execute();
        }*/

        if(PlayerPrefs.GetInt("Morceau1Tableau")==1&&PlayerPrefs.GetInt("Morceau2Tableau")==0&&PlayerPrefs.GetInt("Morceau3Tableau")==0)
        {
            inspect1.Execute();
        }
        if(PlayerPrefs.GetInt("Morceau1Tableau")==1&&PlayerPrefs.GetInt("Morceau2Tableau")==1&&PlayerPrefs.GetInt("Morceau3Tableau")==0)
        {
            inspect2.Execute();
        }
        if(PlayerPrefs.GetInt("Morceau1Tableau")==1&&PlayerPrefs.GetInt("Morceau2Tableau")==1&&PlayerPrefs.GetInt("Morceau3Tableau")==1)
        {
            inspect3.Execute();
            PlayerPrefs.SetInt("PrendreFin",1);
            
        } 
    }
    public void Question()
    {
        if(PlayerPrefs.GetInt("Morceau1Tableau")==0&&PlayerPrefs.GetInt("Morceau2Tableau")==0&&PlayerPrefs.GetInt("Morceau3Tableau")==0)
        {
            inspect0.Execute();
        }
    }


    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }

    public void OnTake()
    {
        Debug.Log("FIN DU JEU");
        Morceau1.SetActive(false);
        Morceau2.SetActive(false);
        Morceau3.SetActive(false);
    }

    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { Observer(); }
    public void OnQuestion() { Question(); }

    public void OnLunchActionAfterCloseDialogue() {}

    public void OnLook() { }

    public void OnDrop() {}

    public void OnPickUp()
    {
    }
}

