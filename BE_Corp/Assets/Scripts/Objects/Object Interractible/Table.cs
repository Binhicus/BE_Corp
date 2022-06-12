using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
using Fungus;

public class Table : ClickableObject, IClicked, IAction
{
    public BlockReference admettre;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public void OnClickAction()
    {
        if(PlayerPrefs.GetInt("Chaise") == 0 && PlayerPrefs.GetInt("Inspect Chair") == 1)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
        }

    }

    public void OnClose()
    {
        
    }

    public void OnInspect()
    {
        
    }

    public void OnLook()
    {
       
    }

    public void OnLunchActionAfterCloseDialogue()
    {
        
    }

    public void OnOpen()
    {
        
    }

    public void OnQuestion()
    {
        Debug.Log("ah oui c'est vrai mdr j'ai abusé");
        admettre.Execute();
        PlayerPrefs.SetInt("Avoue Table", 1);
    }

    public void OnTake()
    {
        
    }

    public void OnUse()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
