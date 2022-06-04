using EPOOutline;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractChecker : ZoomableObject, IClicked
{
    public GameObject radio, closeUpCam, usageCam;
    public BlockReference tips;

    //public UnityEvent onClickAction;
    public void OnClickAction()
    {
        LookZone();
        Activator();
    }

    void Awake()
    {
        usageCam = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraRadio;
    }

    void LookZone()
    {
        closeUpCam.SetActive(true);

        GameObject[] IndiceZoneCollider;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (closeUpCam.activeInHierarchy == false || usageCam.activeInHierarchy == false)
        {
            radio.GetComponent<ClosedRadio>().enabled = false;
            radio.GetComponent<ClosedRadioPile>().enabled = false;
        }
        if(closeUpCam.activeInHierarchy == true || usageCam.activeInHierarchy == true)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<Outlinable>().enabled = false;
        }
    }

    public void Activator()
    {
        if (PlayerPrefs.GetInt("Antenne Branchée") < 1 || PlayerPrefs.GetInt("PileDansRadio") < 1)
        {
          tips.Execute();
        }  
        radio.GetComponent<ClosedRadio>().enabled = true;
        radio.GetComponent<ClosedRadioPile>().enabled = true;
        radio.GetComponent<BoxCollider>().enabled = true;
    }

}
