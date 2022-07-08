using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piles : ClickableObject, IClicked, IItemInventaire, IAction
{
    List<GameObject> zonesZoom = new List<GameObject>();

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Piles";
    public Sprite _Image;

    public Sprite Image => _Image;

    public GameObject _visual;
    public GameObject visual => _visual;

    void Start()
    {

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
        PlayerPrefs.SetInt("Piles", 2);
    }
    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { Debug.Log("Inspect"); }
    public void OnQuestion() { Debug.Log("Question"); }

    public void OnPickUp()
    {
        StartCoroutine(AnimPickUp());
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

    public void OnLook()
    {
        
    }

    public void OnLunchActionAfterCloseDialogue()
    {
        
    }

    IEnumerator AnimPickUp()
    {
        GameObject.Find("Pile Pivot").transform.SetParent(Camera.main.transform);

        foreach(GameObject indiceZone in GameObject.FindGameObjectsWithTag("Indice Zone"))
        {
            zonesZoom.Add(indiceZone);
        }

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            //zonesZoom[i].GetComponent<Collider>().enabled = false;
        }

        Destroy(GameObject.Find("PU_Shine Pile"));
        iTween.MoveTo(GameObject.Find("Pile Pivot"), iTween.Hash("position", new Vector3(-15.2102027f, 9.1944768f, -8.9273609f), "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Pile Pivot"), iTween.Hash("rotation", new Vector3(0f, 220f, 0f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Pile Pivot"), iTween.Hash("scale", new Vector3(0.67495f, 0.67495f, 0.67495f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Pile Pivot"), iTween.Hash("position", new Vector3(20f, 3.575f, -40f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Pile Pivot"), iTween.Hash("scale", new Vector3(0.2f, 0.2f, 0.2f), "time", 0.15f, "delay", 2f));
        Destroy(GameObject.Find("Pile Pivot"), 3f);
        yield return new WaitForSeconds(2.5f);

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            //zonesZoom[i].GetComponent<Collider>().enabled = true;
        }
    }
}