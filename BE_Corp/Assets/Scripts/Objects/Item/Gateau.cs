using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateau : ClickableObject, IClicked, IItemInventaire, IAction
{
    List<GameObject> zonesZoom = new List<GameObject>();

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
        StartCoroutine(AnimPickUp());
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

    IEnumerator AnimPickUp()
    {
        GameObject.Find("Pie Pivot").transform.SetParent(Camera.main.transform);

        foreach (GameObject indiceZone in GameObject.FindGameObjectsWithTag("Indice Zone"))
        {
            zonesZoom.Add(indiceZone);
        }

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = false;
        }

        iTween.MoveTo(GameObject.Find("Pie Pivot"), iTween.Hash("position", GameObject.Find("TargetCuisine").transform.position, "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Pie Pivot"), iTween.Hash("rotation", new Vector3(23.471f, -50.622f, 37.641f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Pie Pivot"), iTween.Hash("scale", new Vector3(0.3f, 0.3f, 0.3f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Pie Pivot"), iTween.Hash("position", GameObject.Find("TargetCuisine").transform.position + new Vector3(-20f, 0f, -20f), "time", 1f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Pie Pivot"), iTween.Hash("scale", new Vector3(0.1f, 0.1f, 0.1f), "time", 0.15f, "delay", 2f));
        Destroy(GameObject.Find("Pie Pivot"), 3f);
        yield return new WaitForSeconds(2.5f);

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = true;
        }
    }
}
