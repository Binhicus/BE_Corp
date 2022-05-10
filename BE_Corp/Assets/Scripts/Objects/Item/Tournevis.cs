using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournevis : ClickableObject, IClicked, IItemInventaire,IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Tournevis";
    public Sprite _Image;
    public AudioSource PickUpSon;

    public Sprite Image => _Image;

    public void Start()
{
    PickUpSon = GameObject.Find("Pickup").GetComponent<AudioSource>();
}

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
        PlayerPrefs.SetInt("Tournevis", 1);
        
    }
    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { Debug.Log("Inspect"); }
    public void OnQuestion() { Debug.Log("Question"); }

    public void OnPickUp()
    {
        PickUpSon.Play();
        gameObject.SetActive(false);
        PickUpSon.Play();
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
}
