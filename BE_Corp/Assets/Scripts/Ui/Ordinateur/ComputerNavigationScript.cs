using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;
using DG.Tweening ;

public class ComputerNavigationScript : MonoBehaviour
{
    public string ComputerName ;
    public Sprite Avatar ;
    public string Date ;
    public string Heure ;
    public ContainerMailScript InformationMail ;

    public Image AvatarLunch ;
    public TextMeshProUGUI NameComputerLunch ;
    public string MailAdress;
    public GameObject MailPastille ;
    public Transform MailStateBar ;
    public Transform WebStateBar ;
    
    public RectTransform LunchWindow ;
    private bool LunchWindowOpen ;

    public RectTransform ShutdownPanel ;


    public RectTransform WindowMail ;
    public RectTransform WindoWMailContainer ;
    public RectTransform WindowScroll ;
    public RectTransform WindowMailDisplayer ;
    private bool MailIsInFullscreen ;
    private bool MailWindowIsOpen = false ;
    [SerializeField] private GameObject MailSecondPlace ;

    public RectTransform WindowWeb ;
    private bool WebIsInFullscreen ;
    private bool WebWindowIsOpen = false ;
    [SerializeField] private GameObject WebSecondPlace ;


    public TextMeshProUGUI HeureDisplay;


    // Start is called before the first frame update
    void Start()
    {
        InformationMail.CurrentDate = Date ;

        AvatarLunch.sprite = Avatar ;
        NameComputerLunch.text = ComputerName ;
    }

    // Update is called once per frame
    void Update()
    {
        if(!InformationMail.AllMailAsRead)
        {
            MailPastille.SetActive(true) ; 
        } else {
            MailPastille.SetActive(false) ;
        }


        HeureDisplay.text = Heure ;
    }

    private void FixedUpdate() 
    {
        if(WindowMail.GetSiblingIndex() == 2) MailSecondPlace.SetActive(false);
        else  MailSecondPlace.SetActive(true);

        if(WindowWeb.GetSiblingIndex() == 2) WebSecondPlace.SetActive(false);
        else  WebSecondPlace.SetActive(true);
    }

    public void OpenLunchWindow()
    {
        if(!LunchWindowOpen)
        {
            LunchWindow.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
            LunchWindow.DOAnchorPosY(0, 0.5f);
        } else {
            LunchWindow.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
            LunchWindow.DOAnchorPosY(-1100f, 0.75f);

            if(ShutdownPanel.gameObject.activeSelf) OpenShutdownPanel();
        }

        LunchWindowOpen = !LunchWindowOpen ;
    }

    public void OpenShutdownPanel()
    {
        if(!ShutdownPanel.gameObject.activeSelf)
        {
            ShutdownPanel.gameObject.SetActive(true) ;
            ShutdownPanel.GetComponent<CanvasGroup>().DOFade(1f, 0.25f);
            ShutdownPanel.DOAnchorPosY(0, 0.25f);
        } else {
            ShutdownPanel.gameObject.SetActive(false) ;
            ShutdownPanel.GetComponent<CanvasGroup>().alpha = 0 ;
            ShutdownPanel.DOAnchorPosY(-50f, 0f);
        }
    }


    public void OpenMail()
    {
        //Affiche la scroll bar et le fond a l'ouverture de la fenêtre
        if(WindowMailDisplayer.transform.GetChild(0).GetComponent<EmailDisplayerScript>().MailDisplay == null) MailDisplaying(false);
        else MailDisplaying(true);

        if(!MailWindowIsOpen)
        {
            MailStateBar.gameObject.SetActive(true);
            MailWindowIsOpen = true ;            
            WindowMail.SetSiblingIndex(2);
            AdaptStateBarWindows();

            if(WindowWeb.gameObject.activeSelf)    WebStateBar.localScale = new Vector2(0.5f, 0.25f);
        } else {
            if(!WindowMail.gameObject.activeSelf)
            {
                MailStateBar.localScale = new Vector2(1f, 0.25f); 
                if(WindowWeb.gameObject.activeSelf)    WebStateBar.localScale = new Vector2(0.5f, 0.25f);
            } 
            else MailStateBar.localScale = new Vector2(0.5f, 0.25f);              
        }


        if(!WindowMail.gameObject.activeSelf)
        {
            WindowMail.gameObject.SetActive(!WindowMail.gameObject.activeSelf) ;
            WindowMail.GetComponent<CanvasGroup>().DOFade(1f, 0.25f) ;

            WindowMail.DOScale(new Vector3(1.001f, 1.001f, 1f), .25f);
            WindowMail.DOAnchorPos(MailIsInFullscreen ? new Vector2(0, 50f) : new Vector2(45f, 50f) , 0.25f);
        } else {
            if(WindowMail.GetSiblingIndex() != 2 && WindowWeb.gameObject.activeSelf)
            {
                WindowMail.SetSiblingIndex(2);
                AdaptStateBarWindows();
            } else {
                WindowMail.GetComponent<CanvasGroup>().DOFade(0f, 0.25f) ;

                WindowMail.DOScale(new Vector3(0.4f, 0.4f, 0.4f), 0.25f);
                WindowMail.DOAnchorPos(new Vector3(-635f, -275f, 0), 0.25f).OnComplete(() => WindowMail.gameObject.SetActive(!WindowMail.gameObject.activeSelf)); 

                if(WindowWeb.gameObject.activeSelf)    WebStateBar.localScale = new Vector2(1f, 0.25f);
     
            }
        }
    }

    public void FullscreenMail(bool IsWeb)
    {
        if(!MailIsInFullscreen)
        {
            MailIsInFullscreen = true ;
            WindowMail.DOAnchorPos(new Vector3(0, 50f, 0), 0.25f);
            WindowMail.DOSizeDelta(new Vector2(1920f, 980f), 0.25f);
            WindoWMailContainer.DOSizeDelta(new Vector2(WindoWMailContainer.sizeDelta.x, 836f), 0.25f);
            WindowScroll.DOSizeDelta(new Vector2(512f, 980f), 0.25f);
            WindowMailDisplayer.DOSizeDelta(new Vector2(1408f, 980f), 0.25f);

            InformationMail.transform.parent.GetComponent<RectTransform>().DOSizeDelta(new Vector3(512f, 836f), 0.05f) ;
            SetMailHeihgt(836f); 
        } else {
            MailIsInFullscreen = false ;
            WindowMail.DOAnchorPos(new Vector3(45f, 50f, 0), 0.25f);
            WindowMail.DOSizeDelta(new Vector2(1536f, 784f), 0.25f);
            WindoWMailContainer.DOSizeDelta(new Vector2(WindoWMailContainer.sizeDelta.x, 640f), 0.25f);
            WindowScroll.DOSizeDelta(new Vector2(512f, 980f), 0.25f);
            WindowMailDisplayer.DOSizeDelta(new Vector2(1024f, 980f), 0.25f);


            InformationMail.transform.parent.GetComponent<RectTransform>().DOSizeDelta(new Vector3(512f, 640f), 0.05f) ;               
            SetMailHeihgt(640f);             
        }      
    }

    public void SetMailHeihgt(float FinalHeightAfterAnimation)
    {

        float HeightHeadMail = 0 ;
        float HeightBlocText = 0 ;
        float MailHeightCalc = 0 ;
        float TotalHeight = 0 ;
        bool MailIsPub = false ;

        HeightHeadMail = WindowMailDisplayer.transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y ;
        HeightBlocText = WindowMailDisplayer.transform.GetChild(0).GetComponent<EmailDisplayerScript>().HeightTextMail ;
        MailIsPub = WindowMailDisplayer.transform.GetChild(0).GetComponent<EmailDisplayerScript>().MailPub ;

        if(!MailIsPub) MailHeightCalc = HeightHeadMail + HeightBlocText ;
        else MailHeightCalc = HeightHeadMail + HeightBlocText + 128f ;


        if(MailHeightCalc < FinalHeightAfterAnimation) TotalHeight = FinalHeightAfterAnimation ;
        else TotalHeight = MailHeightCalc ;

        if(MailIsInFullscreen) WindowMailDisplayer.transform.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(1408f, TotalHeight), 0.25f);
        else WindowMailDisplayer.transform.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(1024f, TotalHeight), 0.25f);
    }

    public void MailDisplaying(bool MailIsDisplay)
    {
        if(MailIsDisplay)
        {
            WindowMailDisplayer.GetComponent<Image>().enabled = true ;

            WindowMailDisplayer.GetComponent<ScrollRect>().enabled = true ;
            WindowMailDisplayer.transform.GetChild(1).gameObject.SetActive(true);
        } else {
            WindowMailDisplayer.GetComponent<Image>().enabled = false ;

            WindowMailDisplayer.GetComponent<ScrollRect>().enabled = false ;
            WindowMailDisplayer.transform.GetChild(1).gameObject.SetActive(false); 
        }
        
    }

    public void CloseMail(bool EraseMailDisplay)
    {
        WindowMail.GetComponent<CanvasGroup>().DOFade(0f, .25f) ;
        WindowMail.DOScale(Vector3.zero, .25f).OnComplete(() => CloseMailWindow());

        if(EraseMailDisplay) 
        {
            WindowMailDisplayer.transform.GetChild(0).GetComponent<EmailDisplayerScript>().MailDisplay = null ;
            WindowMailDisplayer.transform.GetChild(0).GetComponent<EmailDisplayerScript>().SetDisplayer() ;
        }

        if(WindowWeb.gameObject.activeSelf)    WebStateBar.localScale = new Vector2(1f, 0.25f); 
    }

    void CloseMailWindow()
    {
        WindowMail.gameObject.SetActive(false);
        MailStateBar.gameObject.SetActive(false);
        MailWindowIsOpen = false;
    }









    public void OpenWeb()
    {
        //Affiche la scroll bar et le fond a l'ouverture de la fenêtre
        if(!WebWindowIsOpen)
        {
            WebStateBar.gameObject.SetActive(true);
            WebWindowIsOpen = true ;            
            WindowWeb.SetSiblingIndex(2);
            AdaptStateBarWindows();

            if(WindowMail.gameObject.activeSelf)    MailStateBar.localScale = new Vector2(0.5f, 0.25f);
        } else {
            if(!WindowWeb.gameObject.activeSelf) 
            {
                WebStateBar.localScale = new Vector2(1f, 0.25f);
                if(WindowMail.gameObject.activeSelf)    MailStateBar.localScale = new Vector2(0.5f, 0.25f);
            }
            else WebStateBar.localScale = new Vector2(0.5f, 0.25f);  


        }


        if(!WindowWeb.gameObject.activeSelf)
        {
            WindowWeb.gameObject.SetActive(!WindowWeb.gameObject.activeSelf) ;
            WindowWeb.GetComponent<CanvasGroup>().DOFade(1f, 0.25f) ;

            WindowWeb.DOScale(new Vector3(1.001f, 1.001f, 1f), .25f);
            WindowWeb.DOAnchorPos(WebIsInFullscreen ? new Vector2(0, 50f) : new Vector2(-150f, -30f) , 0.25f);
        } else {
            if(WindowWeb.GetSiblingIndex() != 2 && WindowMail.gameObject.activeSelf)
            {
                WindowWeb.SetSiblingIndex(2);
                AdaptStateBarWindows();
            } else {
                WindowWeb.GetComponent<CanvasGroup>().DOFade(0f, 0.25f) ;

                WindowWeb.DOScale(new Vector3(0.4f, 0.4f, 0.4f), 0.25f);
                WindowWeb.DOAnchorPos(new Vector3(-635f, -275f, 0), 0.25f).OnComplete(() => WindowWeb.gameObject.SetActive(!WindowWeb.gameObject.activeSelf));

                if(WindowMail.gameObject.activeSelf)    MailStateBar.localScale = new Vector2(1f, 0.25f);
            }
        }
    }

    public void FullscreenWeb()
    {
        if(!WebIsInFullscreen)
        {
            WebIsInFullscreen = true ;
            WindowWeb.DOAnchorPos(new Vector3(0, 50f, 0), 0.25f);
            WindowWeb.DOSizeDelta(new Vector2(1920f, 980f), 0.25f);
        } else {
            WebIsInFullscreen = false ;              
            WindowWeb.DOAnchorPos(new Vector3(-150f, -30f, 0), 0.25f);
            WindowWeb.DOSizeDelta(new Vector2(1260f, 720f), 0.25f);                        
        }      
    }


    public void CloseWeb()
    {
        WindowWeb.GetComponent<CanvasGroup>().DOFade(0f, .25f) ;
        WindowWeb.DOScale(Vector3.zero, .25f).OnComplete(() => CloseWebWindow());

        if(WindowMail.gameObject.activeSelf)    MailStateBar.localScale = new Vector2(1f, 0.25f);
    }

    void CloseWebWindow()
    {
        WindowWeb.gameObject.SetActive(false);
        WebStateBar.gameObject.SetActive(false);
        WebWindowIsOpen = false;
    }


    public void ShowThisWindowBefore(Transform ThisWindow)
    {
        ThisWindow.SetSiblingIndex(2);
        AdaptStateBarWindows();
    }


    void AdaptStateBarWindows()
    {
        if(WindowMail.GetSiblingIndex() == 2)
        {
            MailStateBar.localScale = new Vector2(1f, 0.25f);
            WebStateBar.localScale = new Vector2(0.5f, 0.25f);
        }

        if(WindowWeb.GetSiblingIndex() == 2)
        {
            MailStateBar.localScale = new Vector2(0.5f, 0.25f); 
            WebStateBar.localScale = new Vector2(1f, 0.25f);              
        }
    }
}
