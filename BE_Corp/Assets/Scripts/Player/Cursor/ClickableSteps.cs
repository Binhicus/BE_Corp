using EPOOutline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSteps : MonoBehaviour
{
    private void OnEnable()
    {
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }
    void OnMouseOver()
    {
        CursorController.Instance.ChangeCursor(CursorType.SceneChange);
        this.gameObject.GetComponent<Outlinable>().enabled = true;
    }

    void OnMouseExit()
    {
        CursorController.Instance.ChangeCursor(CursorType.Default);
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }
}
