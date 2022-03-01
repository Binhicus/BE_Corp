using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour, IClicked
{
    public GameObject CamACharger,CamActuelle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //virtualCam.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //virtualCam.SetActive(false);
        }
    }

    public void OnClickAction()
    {
        CamACharger.SetActive(true);
        CamActuelle.SetActive(false);
    }
}
