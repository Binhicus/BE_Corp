using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Umbrella : ClickableObject, IClicked, IItemInventaire, IAction
{
    List<GameObject> zonesZoom = new List<GameObject>();

    public string nomDuParapluie;
    //private GameObject parapluie;
    public string Name => "Umbrella";

    public Sprite _Image;
    public Sprite Image => _Image;

    public GameObject _visual;
    public GameObject visual => _visual;

    public BlockReference inspect, question;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);            
        }
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
        StartCoroutine(AnimPickUp());
    }


    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }

    public void OnTake()
    {
        Inventaire.Instance.AddItem(this);
        PlayerPrefs.SetInt("Parapluie", 0);
    }

    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { inspect.Execute(); }
    public void OnQuestion() { question.Execute(); }

    public void OnLunchActionAfterCloseDialogue()
    {

    }

    public void OnLook()
    {
        Debug.Log("Observe");
    }

    IEnumerator AnimPickUp()
    {
        GameObject.Find("Umbrella Pivot").transform.SetParent(Camera.main.transform);

        foreach (GameObject indiceZone in GameObject.FindGameObjectsWithTag("Indice Zone"))
        {
            zonesZoom.Add(indiceZone);
        }

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            //zonesZoom[i].GetComponent<Collider>().enabled = false;
        }

        iTween.MoveTo(GameObject.Find("Umbrella Pivot"), iTween.Hash("position", new Vector3(-15.2102027f, 9.1944768f, -8.9273609f), "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Umbrella Pivot"), iTween.Hash("rotation", new Vector3(-50.158f, -28.97f, -97.596f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Umbrella Pivot"), iTween.Hash("scale", new Vector3(0.3f, 0.3f, 0.3f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Umbrella Pivot"), iTween.Hash("position", new Vector3(20f, 3.575f, -40f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Umbrella Pivot"), iTween.Hash("scale", new Vector3(0.1f, 0.1f, 0.1f), "time", 0.25f, "delay", 2f));
        Destroy(GameObject.Find("Umbrella Pivot"), 3f);
        yield return new WaitForSeconds(2.5f);

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            //zonesZoom[i].GetComponent<Collider>().enabled = true;
        }
    }
}
