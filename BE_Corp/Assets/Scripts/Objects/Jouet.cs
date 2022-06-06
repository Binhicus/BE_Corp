using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouet : ClickableObject, IHasItemInteraction, IClicked, IAction
{
    public string nomItem = "Tournevis";
    public string inventoryItemID => nomItem;
    public GameObject piles;
    public BlockReference tip, finito, remarque;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    public void DoItemInteraction()
    {
        piles.SetActive(true);
        PlayerPrefs.SetInt("Piles", 1);
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(piles == null)    piles = GameObject.Find("Piles");
        if(PlayerPrefs.GetInt("Piles") == 1)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.enabled = false;
        }
    }

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    public void OnOpen()
    {
        
    }

    public void OnClose()
    {
        
    }

    public void OnTake()
    {
        
    }

    public void OnUse()
    {
        
    }

    public void OnInspect()
    {
        if (PlayerPrefs.GetInt("Piles") < 1)
        {
            tip.Execute();
        }
        else finito.Execute();

        
    }

    public void OnQuestion()
    {
        remarque.Execute();
    }

    public void OnLook()
    {
        
    }

    public void OnLunchActionAfterCloseDialogue()
    {
        
    }
}
