using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening ;

public enum ZoomZone
{
Zone,
Computer,
Credits,
Setting,
Quit
}

public class ZoomIndiceScript : ZoomableObject, IClicked, IAction
{
    //public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    public ZoomZone WhatIsObjectZoom = ZoomZone.Zone ;
    public GameObject CameraActivate ;

    [Header ("Zoom for Computer")]
    public Color BackgroundComputerClose ;
    public Color BackgroundComptureOpen ;
    public Image BackgroundComputer ;
    public RectTransform ComputerWindow ;

    [Header ("Zoom for Credits")]
    public Image CloseCreditsImageButton ;

    [Header ("Zoom for Setting")]
    public Image CloseSettingImageButton ;
    public Animator anim;


    [Header ("Zoom for Quit the game")]
    public MenuManager MenuManagerScript ;


    void Awake() 
    {
        if(WhatIsObjectZoom == ZoomZone.Computer)
        {
            BackgroundComputer.color = BackgroundComputerClose ;
            ComputerWindow.localScale = Vector3.zero ;
        }

    }



    public void OnClickAction()
    {
        LookZone();
        /*CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);*/
    }

    void LookZone()
    {
        if(WhatIsObjectZoom == ZoomZone.Computer)
        {
            StopAllCoroutines();
            StartCoroutine(LunchLevelComputer());
        }

        if(WhatIsObjectZoom == ZoomZone.Credits)
        {
            StopAllCoroutines();
            CloseCreditsImageButton.raycastTarget = true ;
        }

        if(WhatIsObjectZoom == ZoomZone.Setting)
        {
            StopAllCoroutines();
            CloseSettingImageButton.raycastTarget = true ;
            anim.CrossFade("Fade In", 0.3f);
        }

        if(WhatIsObjectZoom == ZoomZone.Quit)
        {
            StopAllCoroutines();
            if(MenuManagerScript != null) MenuManagerScript.QuitGame();
        }


        CameraActivate.SetActive(true);

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }
    }

    public void ZOSettings()
    {
        anim.CrossFade("Fade Out", 0.3f);
    }



    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() { }
    public void OnQuestion() { }
    public void OnLook() { LookZone(); }


    public void OnLunchActionAfterCloseDialogue() { }


    IEnumerator LunchLevelComputer()
    {
        BackgroundComputer.DOColor(BackgroundComptureOpen, .5f) ;
        yield return new WaitForSeconds(0.4f);
        ComputerWindow.DOScale(Vector3.one, 0.4f);
    }

    public void CloseComputer()
    {
        StopAllCoroutines();
        StartCoroutine(CloseevelComputer());
    }

    IEnumerator CloseevelComputer()
    {
        ComputerWindow.DOScale(Vector3.zero, 0.2f);        
        yield return new WaitForSeconds(0.3f);
        BackgroundComputer.DOColor(BackgroundComputerClose, .5f) ;
    }
}
