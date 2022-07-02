using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EmailDisplayerScript : MonoBehaviour
{
    public Mail MailDisplay ;
    public string MailBoxAdress ;
    
    [Header ("Display Mail Information")]
    [SerializeField] private Image ColorMailBanner ;
    [SerializeField] private TextMeshProUGUI MailObject ;

    [SerializeField] private Image ContactLogo ;
    [SerializeField] private Image FondContactInitiale ;
    [SerializeField] private TextMeshProUGUI ContactInitiale ;


    [SerializeField] private TextMeshProUGUI ContactAdress ;
    [SerializeField] private TextMeshProUGUI DateReception ;
    [SerializeField] private TextMeshProUGUI Destinataire ;
    

    [SerializeField] private RectTransform EmailDisplay ;
    [SerializeField] private Image BannerMailDisplay ;
    private Vector3 ScalePubMail = new Vector3(0.8f, 0.8f, 0.8f);
    private Vector3 ScaleContactMail = new Vector3(0.95f, 0.95f, 0.95f);

    [SerializeField] private TextMeshProUGUI TextMailDisplay ;
    [HideInInspector] public float HeightTextMail ;
    [HideInInspector] public bool MailPub ;
    private float HeightMailCompleted ;
    private bool DisplayScrollBar = false ;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Affiche la scrollbar ou non en fonction des heights
        if(HeightMailCompleted > GetComponent<RectTransform>().sizeDelta.y) DisplayScrollBar = true ;
        else DisplayScrollBar = false ;            


        if(!DisplayScrollBar) transform.parent.GetComponent<ScrollRect>().verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide ;
        else transform.parent.GetComponent<ScrollRect>().verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent ;
    }

    public void SetMailDisplay(Mail NewMailDisplay)
    {
        if(MailDisplay == null) MailDisplay = NewMailDisplay ;
        else {
            if(MailDisplay == NewMailDisplay) MailDisplay = null ;
            else MailDisplay = NewMailDisplay ;
        }

        SetDisplayer();
    }

    public void SetDisplayer()
    {        
        MailBoxAdress = GetComponentInParent<ComputerNavigationScript>().MailAdress ;
        Destinataire.text = "A: " + MailBoxAdress ;        
        
        if(MailDisplay != null)
        {
            this.gameObject.SetActive(true);
            GetComponentInParent<ComputerNavigationScript>().MailDisplaying(true);
            ColorMailBanner.color = MailDisplay.Account.AccountColor ;
            MailObject.text = MailDisplay.Objet ;


            // Affichage d'un logo ou des initiale 
            if(MailDisplay.Account.LogoContact != null)
            {
                ContactLogo.gameObject.SetActive(true) ;
                ContactLogo.sprite = MailDisplay.Account.LogoContact ;
                FondContactInitiale.gameObject.SetActive(false) ;            
            } else {
                ContactLogo.gameObject.SetActive(false) ;

                FondContactInitiale.gameObject.SetActive(true) ;    
                FondContactInitiale.color = MailDisplay.Account.AccountColor ;     
                ContactInitiale.text = GetInitial(MailDisplay.Account.NameAccount) ;
            }

            ContactAdress.text = MailDisplay.Account.NameAccount + " " + "<"+ MailDisplay.Account.MailAdress +">" ;

            // Affichage Date et Heure : xx/xx/xxxx xx:xx
            DateReception.text = MailDisplay.Date.Remove(5) + "  " + MailDisplay.Heure ;






            if(MailDisplay.BannerMail != null) 
            {
                MailPub = true ;
                EmailDisplay.localScale = ScalePubMail ;
                BannerMailDisplay.gameObject.SetActive(true);
                TextMailDisplay.fontSize = 30f ; // 50px = 1.2 ligne
            } else {
                MailPub = false ;
                EmailDisplay.localScale = ScaleContactMail ;
                BannerMailDisplay.gameObject.SetActive(false);
                TextMailDisplay.fontSize = 20f ; // 50px = 2 ligne
            }
            HeightTextMail = MailDisplay.HeightTextBloc ;
            TextMailDisplay.text = MailDisplay.TextMail ;

            GetComponentInParent<ComputerNavigationScript>().SetMailHeihgt(transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        } else {   
            GetComponentInParent<ComputerNavigationScript>().MailDisplaying(false);
            this.gameObject.SetActive(false);
           
        }
    }

    string GetInitial(string Name)
    {
        string InitialFound = "" ;

        string[] Names = Name.Split(' ') ;

        for (int In = 0; In < Names.Length; In++)
        {
            if(Names[In] != "-") InitialFound = InitialFound + Names[In].Substring(0,1);
            else break ;
        }

        return InitialFound ; 
    }
}
