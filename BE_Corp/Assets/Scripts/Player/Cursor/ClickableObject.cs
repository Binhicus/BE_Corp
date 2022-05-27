using EPOOutline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickableObject : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }
    void OnMouseOver()
    {
        CursorController.Instance.ChangeCursor(CursorType.Object);
        this.gameObject.GetComponent<Outlinable>().enabled = true;
    }

    void OnMouseExit()
    {
        CursorController.Instance.ChangeCursor(CursorType.Default);
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }
}
