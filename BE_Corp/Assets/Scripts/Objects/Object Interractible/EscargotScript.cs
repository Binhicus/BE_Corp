using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EscargotScript : ClickableObject, IClicked, IItemInventaire, IAction
{
    public string nomDelEscargot;
    //private GameObject Escargot;
    public string Name => "Petit Escargot";

    public Sprite _Image;
    public Sprite Image => _Image;

    public GameObject _visual;

    public GameObject visual => _visual;

    public BlockReference inspect, question;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.GetInt("Escargot") == 1) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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


    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }

    public void OnTake()
    {
        Inventaire.Instance.AddItem(this);
        PlayerPrefs.SetInt("Escargot", 1);
    }

    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { inspect.Execute(); }
    public void OnQuestion() { question.Execute(); }

    public void OnLunchActionAfterCloseDialogue() {}

    public void OnLook() {    Debug.Log("Observe"); }

    public void OnDrop() {}

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
