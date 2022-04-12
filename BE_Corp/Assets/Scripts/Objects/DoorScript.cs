using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class DoorScript : MonoBehaviour
{
    private SplCameraShake cameraShake;
    [SerializeField] private GameObject Panel;


    private Animator DoorAnimator ;
    [SerializeField] private string PlayerPrefNameState ;
    [SerializeField] private string LeaveStepNameRef ;
    private GameObject LeaveStepRef ;
    private bool MouseOver = false ;
    private bool DoorIsOpen = false ;
    private bool AsCameraShake = false ;

    void Awake()
    {
        DoorAnimator = this.GetComponent<Animator>();     
        if(GameObject.Find(LeaveStepNameRef) != null) LeaveStepRef = GameObject.Find(LeaveStepNameRef);   

        if(GameObject.Find("Panel") != null)
        {
            Panel = GameObject.Find("Panel");
            Panel.SetActive(false);            
        }

        if(this.gameObject.GetComponent<SplCameraShake>() != null)
        {
            cameraShake = this.gameObject.GetComponent<SplCameraShake>();   
            AsCameraShake = true ;         
        }
        

    }

    private void Start() 
    {
        VerifAnimation();
    }

    void VerifAnimation()
    {
        if(PlayerPrefs.GetInt(PlayerPrefNameState) == 0)
        {
            LeaveStepRef.GetComponent<DynamicLoad>().DispStep(false);
        } else {
            LeaveStepRef.GetComponent<DynamicLoad>().DispStep(true);
            DoorIsOpen = true ;
            DoorAnimator.SetTrigger("Open");            
        }
    }

    void OnMouseOver()
    {
        MouseOver = true ;

        if(!DoorIsOpen && AsCameraShake && cameraShake.enabled == true)
        {
            cameraShake.Shaker();
            Panel.SetActive(true);         
        }
    }

    void OnMouseExit()
    {
        MouseOver = false ;

        if(!DoorIsOpen && AsCameraShake)
        {
            Panel.SetActive(false);            
        }
    }


    public void OpenDoorAnimation()
    {
        cameraShake.enabled = false ;
        cameraShake.triggered = false ;
        DoorIsOpen = true ;
        StartCoroutine(DoorAnimation());
    }
    

    IEnumerator DoorAnimation()
    {
        yield return new WaitForSeconds(2.0f);
        DoorAnimator.SetTrigger("Door Animation");        
        yield return new WaitForSeconds(1.0f);
        LeaveStepRef.GetComponent<DynamicLoad>().DispStep(true);
    }
}
