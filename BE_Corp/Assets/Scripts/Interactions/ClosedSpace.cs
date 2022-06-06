using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ClosedSpace : MonoBehaviour, IHasItemInteraction, IClicked, IAction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject fog, bloqueur;
    public GameObject OuverturePorteChambre;

    public BlockReference question, inspect ;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    public List<ActionWheelChoiceData> ListInteractPossible2 = new List<ActionWheelChoiceData>() ;



    private SplCameraShake cameraShake;
    private bool MouseOver = false ;
    private bool AsCameraShake = false ;


    private void Awake() 
    {
        if(this.gameObject.GetComponent<SplCameraShake>() != null)
        {
            cameraShake = this.gameObject.GetComponent<SplCameraShake>();   
            AsCameraShake = true ;         
        }

        fog = GameObject.Find("Gray Volume Fog");
        OuverturePorteChambre=GameObject.Find("Ouverture");
    }

  /*  void OnMouseOver()
    {
        MouseOver = true ;

        if(AsCameraShake && cameraShake.enabled == true)
        {
            if(cameraShake != null) cameraShake.Shaker();
            GlitchyBreak.Instance.GlitchEffectOn();
        }
    }

    void OnMouseExit()
    {
        MouseOver = false ;

        if(AsCameraShake)
        {
            GlitchyBreak.Instance.GlitchEffectOff();
        }
    }*/


    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            if(PlayerPrefs.GetInt("Scarecrow") == 0) CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
            else CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible2 ;
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);          
        }

    }

    public void DoItemInteraction()
    {
        fog.GetComponentInChildren<ParticleSystem>().Stop();
        fog.GetComponent<BoxCollider>().enabled = false;
        bloqueur.SetActive(false);
        PlayerPrefs.SetInt("Brume", 1);
        OuverturePorteChambre.GetComponent<BoxCollider>().enabled=true;
        Jauge.Instance.stadeProg += 1;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        fog = GameObject.Find("Gray Volume Fog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  void Awake()
    {

    }*/

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() {inspect.Execute(); }
    public void OnQuestion() {question.Execute(); }
    public void OnLook() {}

    public void OnLunchActionAfterCloseDialogue() {}
}
