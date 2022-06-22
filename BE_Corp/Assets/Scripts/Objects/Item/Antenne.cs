using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Antenne : ClickableObject, IClicked, IItemInventaire, IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Antenne";
    public Sprite _Image;
    public BlockReference inspect;

    public GameObject _visual;
    public GameObject visual => _visual;
    public Sprite Image => _Image;

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
        PlayerPrefs.SetInt("Antenne", 1);
    }
    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { inspect.Execute(); }
    public void OnQuestion() { Debug.Log("Question"); }

    public void OnPickUp()
    {
        AnimPickUp();
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
    public void OnLook() {}
    public void OnLunchActionAfterCloseDialogue() {}

    void AnimPickUp()
    {
        iTween.MoveTo(GameObject.Find("Antenne Pivot"), iTween.Hash("position", new Vector3(-33.3230014f, 3.575f, -4.9f), "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Antenne Pivot"), iTween.Hash("rotation", new Vector3(0f, 200.382f, 0f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Antenne Pivot"), iTween.Hash("scale", new Vector3(0.16f, 0.16f, 0.16f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Antenne Pivot"), iTween.Hash("position", new Vector3(0f, 3.575f, -4.9f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Antenne Pivot"), iTween.Hash("scale", new Vector3(0.0684f, 0.0684f, 0.0684f), "time", 0.3f, "delay", 2f));
        Destroy(GameObject.Find("Antenne Pivot"), 3f);
    }
}
