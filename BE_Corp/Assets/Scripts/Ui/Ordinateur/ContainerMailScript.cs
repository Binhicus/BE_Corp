using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class ContainerMailScript : MonoBehaviour
{
    public List<Mail> AllMail ;

    private List<Mail> MailSort = new List<Mail>() ;

    public GameObject PrefabDateRibbon ;
    public GameObject PrefabMailDisplayer ;

    public bool AllMailAsRead ;
    [HideInInspector] public string CurrentDate ;
    private string[] DateJour = new string[] {"Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Diamnche"} ;
    private string[] DateMois = new string[] {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"} ;


    void Start()
    {
        SetMailSort();
    }




    void SetMailSort()
    {
        List<Mail> MailListSort = AllMail; 

        MailListSort = MailListSort.OrderBy(ML => GetNumerateDate(ML.Date, ML.Heure)).ToList() ;

        MailSort = MailListSort ;
        MailSort.Reverse();

        CreateEmailBox();
    }    

    long GetNumerateDate(string Date, string Heure)
    {
        long CompletedDate ;

        string[] Dates = Date.Split('/') ; //  JJ / MM / YYYY 
        string[] HeureMinute = Heure.Split(char.Parse(":")) ; // HH  /  MM

        string NumerateDate = Dates[2] + Dates[1] + Dates[0] + HeureMinute[0] + HeureMinute[1] ;

        CompletedDate = System.Convert.ToInt64(NumerateDate);

        return CompletedDate ;
    }

    long GetDate(string Date) 
    {
        long CompletedDate ;
        string[] Dates = Date.Split('/') ; //  JJ / MM / YYYY 

        string NumerateDate = Dates[2] + Dates[1] + Dates[0] ;

        CompletedDate = System.Convert.ToInt64(NumerateDate);

        return CompletedDate ;
    }


    void CreateEmailBox()
    {
        foreach(Transform Children in transform) 
        {
            Destroy(Children.gameObject);
        }

        int EmailInstantiate = 0 ;
        for (int Ms = 0; Ms < MailSort.Count; Ms++)
        {
            bool DisplayHour = false ;
            if(Ms == 0 || (GetDate(MailSort[Ms].Date) != GetDate(MailSort[Ms-1].Date)))
            {
                GameObject DateBox = Instantiate(PrefabDateRibbon);
                DateBox.transform.SetParent(this.transform);

                DateBox.transform.localPosition = new Vector3(DateBox.transform.localPosition.x, DateBox.transform.localPosition.y, 0);
                DateBox.transform.localScale = Vector3.one ;


                TextMeshProUGUI DateBoxchild = DateBox.GetComponentInChildren<TextMeshProUGUI>() ;
                if(Ms == 0) DateBoxchild.text = GetRibbonText(MailSort[Ms].Date, CurrentDate);
                else DateBoxchild.text = GetRibbonText(MailSort[Ms].Date, MailSort[Ms - 1].Date);
                
                
                if(DateBoxchild.text == "Aujourd'hui" || DateBoxchild.text == "Today") DisplayHour = true ;
            }

            GameObject MailInBox = Instantiate(PrefabMailDisplayer);
            MailInBox.transform.SetParent(this.transform);

            MailInBox.transform.localPosition = new Vector3(MailInBox.transform.localPosition.x, MailInBox.transform.localPosition.y, 0);
            MailInBox.transform.localScale = Vector3.one ;

            EmailContainerScript MailInBoxContainerScript = MailInBox.GetComponent<EmailContainerScript>();
            MailInBoxContainerScript.MailInformations = MailSort[Ms];
            MailInBoxContainerScript.ThisAsBeenReceiveToday = DisplayHour ;

            MailInBoxContainerScript.SetMailButton();
            EmailInstantiate ++ ;
        }
    }

    string GetRibbonText(string DateBeChecked, string DateRef)
    {
        string GetRibbonText = "" ;


        if(GetDate(DateBeChecked) > GetDate(DateRef))    GetRibbonText = "Mail du FUTUR" ;

        if(GetDate(DateBeChecked) == GetDate(DateRef))    GetRibbonText = "Aujourd'hui" ;
        if((GetDate(DateBeChecked) + 1) == GetDate(DateRef))    GetRibbonText = "Hier" ;

        if((GetDate(DateBeChecked) + 2) <=  GetDate(DateRef))
        {
            GetRibbonText = "Faut encore que je le fasse zebis" ;
        }    

        return GetRibbonText ;
    }



















    bool CheckMailBoxState()
    {
        bool AllMailAsBeRead = true ;

        foreach(Transform Child in transform)
        {
            if(Child.GetComponent<EmailContainerScript>() != null)
            {
                if(Child.GetComponent<EmailContainerScript>().ThisMailAsBeRead == false) AllMailAsBeRead = false ;
            }
        }

        return AllMailAsBeRead ;
    }


    void Update()
    {
        AllMailAsRead = CheckMailBoxState() ;
    }




}
