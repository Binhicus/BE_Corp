using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSteps : MonoBehaviour
{
    void OnMouseOver()
    {
        CursorController.Instance.ChangeCursor(CursorType.SceneChange);
    }

    void OnMouseExit()
    {
        CursorController.Instance.ChangeCursor(CursorType.Default);
    }
}
