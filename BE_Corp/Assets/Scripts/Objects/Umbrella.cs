using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : ClickableObject, IClicked, IItemInventaire, IAction
{
    public string nomDuParapluie;
    private GameObject parapluie;
    public string Name => "Umbrella";

    public Sprite _Image;
    public Sprite Image => _Image;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    public void OnDrop()
    {
        Debug.Log(this);
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        parapluie = GameObject.Find(nomDuParapluie);
    }

    public void OnOpen()
    {
        throw new System.NotImplementedException();
    }

    public void OnClose()
    {
        throw new System.NotImplementedException();
    }

    public void OnTake()
    {
        Inventaire.Instance.AddItem(this);
    }

    public void OnUse()
    {
        throw new System.NotImplementedException();
    }

    public void OnInspect()
    {
        throw new System.NotImplementedException();
    }

    public void OnQuestion()
    {
        throw new System.NotImplementedException();
    }

    public void OnLunchActionAfterCloseDialogue()
    {
        throw new System.NotImplementedException();
    }
}
