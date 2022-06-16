using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateau : ClickableObject, IClicked, IItemInventaire, IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Gateau";
    public Sprite _Image;

    public Sprite Image => _Image;

    public GameObject _visual;
    public GameObject visual => _visual;

    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }
    public void OnTake()
    {
        Inventaire.Instance.AddItem(this);
    }
    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { Debug.Log("Inspect"); }
    public void OnQuestion() { Debug.Log("Question"); }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Gateau",1);
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

    void Awake()
    {
        if(PlayerPrefs.GetInt("Gateau")==1)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnLook() {}
    public void OnLunchActionAfterCloseDialogue() {}
}
