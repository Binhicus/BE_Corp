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

    public GameObject _visual;
    public GameObject visual => _visual;

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
        StartCoroutine(AnimPickUp());
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

    public void OnLook()
    {
        Debug.Log("Observe");
    }

    IEnumerator AnimPickUp()
    {
        GameObject.Find("Clef Pivot").transform.SetParent(Camera.main.transform);
        Destroy(GameObject.Find("PU_shine Key"));
        iTween.MoveTo(GameObject.Find("Clef Pivot"), iTween.Hash("position", new Vector3(-15.2102027f, 9.1944768f, -8.9273609f), "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Clef Pivot"), iTween.Hash("rotation", new Vector3(135.084f, -34.272f, 0f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Clef Pivot"), iTween.Hash("scale", new Vector3(1.35147f, 1.35147f, 1.35147f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Clef Pivot"), iTween.Hash("position", new Vector3(20f, 3.575f, -40f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Clef Pivot"), iTween.Hash("scale", new Vector3(0.2f, 0.2f, 0.2f), "time", 0.15f, "delay", 2f));
        Destroy(GameObject.Find("Clef Pivot"), 3f);
        yield return new WaitForSeconds(2.5f);
    }
}
