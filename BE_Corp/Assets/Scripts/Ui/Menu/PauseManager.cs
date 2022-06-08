using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        CursorController.Instance.OnEnable();
    }

    // Update is called once per frame
    void OnDisable()
    {
        CursorController.Instance.OnDisable();
    }
}
