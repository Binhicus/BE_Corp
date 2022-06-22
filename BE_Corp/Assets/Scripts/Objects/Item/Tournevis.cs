using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournevis : ClickableObject, IClicked, IItemInventaire,IAction
{
    Animation anim;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Tournevis";
    public Sprite _Image;

    public Sprite Image => _Image;

    public GameObject _visual;
    public GameObject visual => _visual;

    void Start()
    {
        anim = GameObject.Find("Tournevis Pivot").GetComponent<Animation>();
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
        iTween.MoveTo(GameObject.Find("Tournevis Pivot"), iTween.Hash("position", new Vector3(-33.349f, 4.05f, -5.04f), "time", 0.9f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.RotateTo(GameObject.Find("Tournevis Pivot"), iTween.Hash("rotation", new Vector3(38.1756592f, 30.2754154f, 269.498077f), "time", 1f, "delay", 0.9f));
        iTween.ScaleTo(GameObject.Find("Tournevis Pivot"), iTween.Hash("scale", new Vector3(0.047775995f, 0.0761041194f, 0.0537382551f), "time", 0.5f, "delay", 0.9f));
        iTween.MoveTo(GameObject.Find("Tournevis Pivot"), iTween.Hash("position", new Vector3(0f, 4.05f, -5.04f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine, "delay", 2f));
        iTween.ScaleTo(GameObject.Find("Tournevis Pivot"), iTween.Hash("scale", new Vector3(0.0194141064f, 0.0309254341f, 0.0218369141f), "time", 0.3f, "delay", 2f));
        Destroy(GameObject.Find("Tournevis Pivot"), 3f);
    }
}
