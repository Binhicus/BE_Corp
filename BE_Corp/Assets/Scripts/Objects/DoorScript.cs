using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject TextePo;
    public SplCameraShake cameraShake;
    public GameObject Panel;

    public GameObject PasDePorte ;

    private bool DoorIsOpen = false ;
    private bool AsCameraShake = false ;

    void Awake()
    {
        if(GameObject.Find("Panel").gameObject != null)
        {
            Panel = GameObject.Find("Panel").gameObject;
            Panel.SetActive(false);            
        }

        if(this.gameObject.GetComponent<SplCameraShake>() != null)
        {
            cameraShake = this.gameObject.GetComponent<SplCameraShake>();   
            AsCameraShake = true ;         
        }
    }

    void OnMouseOver()
    {
        if(!DoorIsOpen && AsCameraShake)
        {
            cameraShake.Shaker();
            Panel.SetActive(true);         
        }
    }

    void OnMouseExit()
    {
        if(!DoorIsOpen && AsCameraShake)
        {
            Panel.SetActive(false);            
        }
    }


    public void OpenDoorAnimation()
    {
        DoorIsOpen = true ;
        StartCoroutine(DoorAnimation());
    }

    IEnumerator DoorAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("Go");
        yield return new WaitForSeconds(6.0f);
        PasDePorte.SetActive(true);

    }
}
