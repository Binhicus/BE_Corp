using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueInputPausedController : MonoBehaviour
{
    [SerializeField] private DialogInput DI ;

    void FixUpdate()
    {
        if(GameObject.Find("Mouse On") == null && DI.enabled)
        {
            DI.enabled = false ;
        }

        if(GameObject.Find("Mouse On") != null && !DI.enabled)
        {
            DI.enabled = true ;
        }
    }
}
