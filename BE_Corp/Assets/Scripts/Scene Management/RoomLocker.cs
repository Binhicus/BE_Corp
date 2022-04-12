using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLocker : MonoBehaviour, IClicked
{
    public GameObject[] chargeurs;
    public void OnClickAction()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        for (int i = 0; i < chargeurs.Length; i++)
        {
            chargeurs[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}
