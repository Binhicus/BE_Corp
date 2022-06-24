using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class EscargotScript : ClickableObject, IClicked, IItemInventaire, IAction
{
    Button dezoom;

    public string nomDelEscargot;
    //private GameObject Escargot;
    public string Name => "Petit Escargot";

    public Sprite _Image;
    public Sprite Image => _Image;

    public GameObject _visual;

    public GameObject visual => _visual;

    public BlockReference inspect, question;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.GetInt("Escargot") == 1) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        PlayerPrefs.SetInt("Escargot", 1);
    }

    public void OnUse() { Debug.Log("Use"); }
    public void OnInspect() { inspect.Execute(); }
    public void OnQuestion() { question.Execute(); }

    public void OnLunchActionAfterCloseDialogue() {}

    public void OnLook() {    Debug.Log("Observe"); }

    public void OnDrop() {}

    public void OnPickUp()
    {
        StartCoroutine(AnimPickUp());
    }

    IEnumerator AnimPickUp()
    {
        dezoom = GameObject.Find("Dezoom").GetComponent<Button>();
        dezoom.interactable = false;
        iTween.MoveTo(GameObject.Find("Statuette Pivot"), iTween.Hash("position", new Vector3(-13.8982f, 5.565477f, -9.586361f), "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Statuette Pivot"), iTween.Hash("rotation", new Vector3(0f, 220f, 0f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Statuette Pivot"), iTween.Hash("scale", new Vector3(0.1515318f, 0.1515318f, 0.1515318f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Statuette Pivot"), iTween.Hash("position", new Vector3(10f, 3.575f, -45f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Statuette Pivot"), iTween.Hash("scale", new Vector3(0.04553575f, 0.04553575f, 0.04553575f), "time", 0.15f, "delay", 2f));
        Destroy(GameObject.Find("Statuette Pivot"), 3f);
        yield return new WaitForSeconds(2.5f);
        dezoom.interactable = true;
    }
}
