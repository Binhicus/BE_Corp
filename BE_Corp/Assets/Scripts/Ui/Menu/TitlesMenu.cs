using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlesMenu : MonoBehaviour
{
    public HoverElementMask TheTitle ;
    public GameObject LeNom;
    void OnMouseOver()
    {
        TheTitle.ShowElement();
        //LeNom.SetActive(true);
    }


     void OnMouseExit()
    {
        TheTitle.HideElement();
        //LeNom.SetActive(false);
    }
}
