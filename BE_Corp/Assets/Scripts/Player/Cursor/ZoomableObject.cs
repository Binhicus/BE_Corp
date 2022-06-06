using EPOOutline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomableObject : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }
    void OnMouseOver()
    {
        CursorController.Instance.ChangeCursor(CursorType.Observe);
        this.gameObject.GetComponent<Outlinable>().enabled = true;
    }

    void OnMouseExit()
    {
        CursorController.Instance.ChangeCursor(CursorType.Default);
        this.gameObject.GetComponent<Outlinable>().enabled = false;
    }
}
