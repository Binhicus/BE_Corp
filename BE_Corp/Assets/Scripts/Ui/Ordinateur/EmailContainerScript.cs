using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailContainerScript : MonoBehaviour
{

    public Mail MailInformations ;
    [Space(15)]
    [SerializeField] private Image LogoContact ;
    [SerializeField] private Image FondInitiale ;
    [SerializeField] private TextMeshProUGUI InitialeContact ;

    [SerializeField] private TextMeshProUGUI TitleNameContact ;
    [SerializeField] private TextMeshProUGUI DateHoursReveice ;
    [HideInInspector] public bool ThisAsBeenReceiveToday = false ;
    [SerializeField] private TextMeshProUGUI ObjectMail ;
    [SerializeField] private TextMeshProUGUI DescriptionMail ;
    [Space(15)]
    [HideInInspector] public bool ThisMailAsBeRead ;
    [SerializeField] private GameObject NonLuIndication ;
    [SerializeField] private Color MailLu ;
    [SerializeField] private Color MailNonLu ;


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
   
   
    void Start()
    {

    }

    public void SetMailButton()
    {
        ThisMailAsBeRead = MailInformations.MailLu ;
                
        // Affichage d'un logo ou des initiale 
        if(MailInformations.Account.LogoContact != null)
        {
            LogoContact.gameObject.SetActive(true) ;
            LogoContact.sprite = MailInformations.Account.LogoContact ;
            FondInitiale.gameObject.SetActive(false) ;            
        } else {
            LogoContact.gameObject.SetActive(false) ;

            FondInitiale.gameObject.SetActive(true) ;    
            FondInitiale.color = MailInformations.Account.AccountColor ;     
            InitialeContact.text = GetInitial(MailInformations.Account.NameAccount) ;
        }


        TitleNameContact.text = MailInformations.Account.NameAccount ;
        
        // Ajout variante si date == jour actuel
        if(ThisAsBeenReceiveToday) DateHoursReveice.text = MailInformations.Heure ;
        else DateHoursReveice.text = MailInformations.Date.Remove(5) /*+ " " + *GetPartOfTheDate(MailInformations.Date, 1) + " " + MailInformations.Heure*/ ;

        ObjectMail.text = MailInformations.Objet ;
        DescriptionMail.text = MailInformations.Description ;

        MailReadOrNot(MailInformations.MailLu) ;

    }


    string GetPartOfTheDate(string Date, int PartNeed)
    {
        string[] Dates = Date.Split('/') ; //  JJ / MM / YYYY 
        string[] Month = new string[] {"janv.", "févr.", "mars", "avr.", "mai", "juin", "juil.", "aout", "sept."," oct.", "nov.", "déc."};

        if(PartNeed != 1) return Dates[PartNeed];
        else return Month[PartNeed] ;
    }

    void MailReadOrNot(bool MailAsBeRead)
    {
        if(MailAsBeRead)
        {
            NonLuIndication.SetActive(false) ;
            NonLuIndication.GetComponent<Image>().color = MailLu ;

            ObjectMail.color = MailLu ;
            ObjectMail.fontStyle = FontStyles.Normal ;

            DateHoursReveice.color = MailLu ;
            DateHoursReveice.fontStyle = FontStyles.Normal ;
        } else {
            NonLuIndication.SetActive(true) ;
            NonLuIndication.GetComponent<Image>().color = MailNonLu ;

            ObjectMail.color = MailNonLu ;
            ObjectMail.fontStyle = FontStyles.Bold ;

            DateHoursReveice.color = MailNonLu ;
            DateHoursReveice.fontStyle = FontStyles.Bold ;
        }
    }


    public void OpenningMail()
    {
        ThisMailAsBeRead = true ;
        MailReadOrNot(ThisMailAsBeRead) ;

        GetComponentInParent<ContainerMailScript>().EmailDisplayerManager.SetMailDisplay(MailInformations);

        if (MailInformations.IsStoryMail)
        {
            PlayerPrefs.SetInt("Salon Révélé", 1);
            MisAJourEffect.Instance.TableauReveal();
            Jauge.Instance.stadeProg += 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
