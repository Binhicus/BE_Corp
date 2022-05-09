using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Fungus;

public class CheckPoint : Singleton<CheckPoint>
{
    [TextArea] public string champTxt;
    public Transform imageTransform;
    public Image logo;
    public CanvasGroup contenu;
    public FlowchartData texte;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        champTxt = this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        imageTransform = GameObject.Find("Logo").transform;
        logo = this.gameObject.GetComponentInChildren<Image>();
        logo.enabled = false;
    }

    // Update is called once per frame
    public void MiseAJour()
    {
        champTxt = "Le souvenir a été mis à jour.";
        
    }
    
    public void LogoSpin()
    {
        //texte.
    }

    public void CanvasFade()
    {

    }
}
