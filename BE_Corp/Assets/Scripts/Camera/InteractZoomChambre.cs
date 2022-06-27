using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractZoomChambre : ZoomableObject, IClicked
{
   public GameObject closeUpCam;

    //public UnityEvent onClickAction;
    public void OnClickAction()
    {
        LookZone();
    }

    void Awake()
    {
       // usageCam = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraMeubleChambre;
        closeUpCam = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraMeubleChambre;
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
        if(closeUpCam.activeInHierarchy == true)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
           // this.gameObject.GetComponent<Outlinable>().enabled = false;
        }
    }
}
