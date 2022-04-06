using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ClickableObject, IClicked, IItemInventaire, IAction
{
    public string nomDeLaClef;
    private GameObject key;

    public string Name => "Clef";
    public Sprite _Image;
    public Sprite Image => _Image;

    public Texture2D cursor;
    public Texture2D regularCursor;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    //public string matricule;
    //public string itemID => matricule;

    private void OnEnable()
    {
        key = GameObject.Find(nomDeLaClef);
    }
    public void OnClickAction()
    {
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }

    //les 2 fonctions suivantes sont à reprendre pour chaque objet nécessitant d'être dans l'inventaire
    public void OnPickUp()
    {
        //Debug.Log("Oui oui rab");
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("VaseAndKey", 2);
    }

    public void OnDrop()
    {
        Debug.Log(this);
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
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

    public void OnLunchActionAfterCloseDialogue()
    {

    }
}
