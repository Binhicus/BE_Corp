using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournevis : ClickableObject, IClicked, IItemInventaire,IAction
{
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Tournevis";
    public Sprite _Image;

    public Sprite Image => _Image;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        GetComponent<Animator>().keepAnimatorControllerStateOnDisable = true;
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
        StartCoroutine(DelayAnimPickNDrop());
        gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        Debug.Log(this);
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            StartCoroutine(DelayAnimPickNDrop());
            gameObject.transform.position = hit.point;
        }
    }
    public void OnLook() {}
    public void OnLunchActionAfterCloseDialogue() {}

    IEnumerator DelayAnimPickNDrop()
    {
        if (anim.GetBool("PickUp") == false)
        {
            anim.SetBool("PickUp", true);
            yield return new WaitForSeconds(3f);
        }
        else
        {
            anim.SetBool("PickUp", false);
            yield return new WaitForSeconds(3f);
        }
    }
}
