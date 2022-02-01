using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;
using DG.Tweening ;

public class ComputerNavigationScript : MonoBehaviour
{
    public string Date ;
    public string Heure ;
    public ContainerMailScript InformationMail ;
    public GameObject MailPastille ;
    public Transform MailStateBar ;

    public RectTransform WindowMail ;
    private bool MailIsInFullscreen ;
    private bool MailWindowIsOpen = false ;

    public TextMeshProUGUI HeureDisplay;


    // Start is called before the first frame update
    void Start()
    {
        InformationMail.CurrentDate = Date ;
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

    public void OpenMail()
    {
        if(!MailWindowIsOpen)
        {
            MailStateBar.gameObject.SetActive(true);
            MailWindowIsOpen = true ;
        } else {
            if(!WindowMail.gameObject.activeSelf) MailStateBar.localScale = new Vector2(1f, 1);
            else MailStateBar.localScale = new Vector2(0.5f, 1);
        }


        if(!WindowMail.gameObject.activeSelf)
        {
            WindowMail.gameObject.SetActive(!WindowMail.gameObject.activeSelf) ;
            WindowMail.GetComponent<CanvasGroup>().DOFade(1f, 1f) ;

            WindowMail.DOScale(Vector3.one, 1f);
            WindowMail.DOAnchorPos(MailIsInFullscreen ? new Vector2(0, 50f) : new Vector2(45f, 50f) , 1f);
        } else {

            WindowMail.GetComponent<CanvasGroup>().DOFade(0f, 1f) ;

            WindowMail.DOScale(new Vector3(0.4f, 0.4f, 0.4f), 1f);
            WindowMail.DOAnchorPos(new Vector3(-635f, -275f, 0), 1f).OnComplete(() => WindowMail.gameObject.SetActive(!WindowMail.gameObject.activeSelf));
        }
    }

    public void FullscreenMail(bool IsWeb)
    {
        if(!MailIsInFullscreen)
        {
            MailIsInFullscreen = true ;
            WindowMail.DOAnchorPos(new Vector3(0, 50f, 0), 1f);
            WindowMail.DOSizeDelta(new Vector2(1920f, 980f), 1f);

            InformationMail.transform.parent.GetComponent<RectTransform>().DOSizeDelta(new Vector3(512f, 836f), 1f) ;
        } else {
            MailIsInFullscreen = false ;
            WindowMail.DOAnchorPos(new Vector3(45f, 50f, 0), 1f);
            WindowMail.DOSizeDelta(new Vector2(1536f, 784f), 1f);

            InformationMail.transform.parent.GetComponent<RectTransform>().DOSizeDelta(new Vector3(512f, 640f), 1f) ;                
        }      
    }

    public void CloseMail()
    {
        WindowMail.GetComponent<CanvasGroup>().DOFade(0f, .25f) ;
        WindowMail.DOScale(Vector3.zero, .35f).OnComplete(() => CloseMailWindow());
    }

    void CloseMailWindow()
    {
        WindowMail.gameObject.SetActive(false);
        MailStateBar.gameObject.SetActive(false);
        MailWindowIsOpen = false;
    }

}
