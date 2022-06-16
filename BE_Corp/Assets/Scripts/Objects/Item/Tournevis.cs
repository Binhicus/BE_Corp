using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournevis : ClickableObject, IClicked, IItemInventaire,IAction
{
    Animator anim;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public string Name => "Tournevis";
    public Sprite _Image;

    public Sprite Image => _Image;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.keepAnimatorControllerStateOnDisable = true;
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
        StartCoroutine(AnimInventaire());

        if (GameObject.Find("Cam_Commode Entrée").active = true)
        {
            transform.position = GameObject.Find("Target pick").transform.position;
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
    public void OnLook() {}
    public void OnLunchActionAfterCloseDialogue() {}

    IEnumerator AnimInventaire()
    {
        if (anim.GetBool("Phase 1") == false)
        {
            anim.SetBool("Phase 1", true);
            yield return new WaitForSeconds(3f);
            anim.SetBool("Phase 2", true);
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
        else
        {
            anim.SetBool("Phase 1", false);
            yield return new WaitForSeconds(2f);
        }
    }
}
