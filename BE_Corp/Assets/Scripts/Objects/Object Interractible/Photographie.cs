using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photographie : ClickableObject, IClicked, IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public BlockReference questionnement;
    private EntreeManager entreeManager;

    void Awake()
    {
        entreeManager = GameObject.Find("EntréeManager").GetComponent<EntreeManager>();
    }
    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    public void OnClose()
    {
    }

    public void OnInspect()
    {
        //inspection.Execute();
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
        questionnement.Execute();
        PlayerPrefs.SetInt("Séquence 1 Done", 1);
        entreeManager.IntroState();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
