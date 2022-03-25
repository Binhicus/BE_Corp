using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    void OnMouseOver()
    {
        CursorController.Instance.ChangeCursor(CursorType.Object);
    }

    void OnMouseExit()
    {
        CursorController.Instance.ChangeCursor(CursorType.Default);
    }
}
