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
    [Space(25)]
    public GameObject PrefabDateRibbon ;
    public GameObject PrefabMailDisplayer ;
    [Space(5)]
    public bool AllMailAsRead ;
    [Space(15)]
    public EmailDisplayerScript EmailDisplayerManager ;
    
    [HideInInspector] public string CurrentDate ;
    private string[] DateJour = new string[] {"Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Diamnche"} ;
    private string[] DateMois = new string[] {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"} ;


    void Start()
    {
        StartCoroutine(WaitAndSet());
    }
    IEnumerator WaitAndSet()
    {
        yield return new WaitForSeconds(1f);
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

        if((GetDate(DateBeChecked) + 2) <  GetDate(DateRef))
        {
            //GetRibbonText = "Faut encore que je le fasse zebis" ;
            GetRibbonText = GetDayOfTheDate(DateBeChecked) + " " + GetPartOfTheDate(DateBeChecked, 0) + " " + GetPartOfTheDate(DateBeChecked, 1) + " " + GetPartOfTheDate(DateBeChecked, 2) ;
        }    

        return GetRibbonText ;
    }

    string GetDayOfTheDate(string Date)
    {
        //string DaysReturn = "" ;
        string[] Days = new string[] {"dimanche", "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi"} ;
        string[] Dates = Date.Split('/') ; //  JJ / MM / YYYY      

        int Etape1 = 0 ; 
        int Etape2 = 0 ;
        int Etape3 = 0 ; 
        int Etape4 = 0 ;
        int Etape5 = 0 ;
        int Etape6 = 0 ;

        /* Etape 1 : Avoir le jour du mois */
        Etape1 = int.Parse(Dates[0]) ;


        /* Etape 2 : Enlever les siècle et ne gardez que les décénies */
        int Decade = int.Parse(Dates[2].Substring(Dates[2].Length - 2));
        Etape2 = Decade ;


        /* Etape 3 : Récupérer le nombre d'année bisextile, Divisez par 4 pour retire les années bisextile, si le résultat est net et que le mois est janvier ou février, on retire 1, si le résultat est décimale, on ajoute 1 */
        int NmBisYears = 0;
        while(Decade > 3)
        {
            Decade -= 4 ;            
            NmBisYears ++ ;
        }

        if(Decade != 0) Etape3 = NmBisYears + 1 ;
        else {
            if((int.Parse(Dates[1]) < 3)) Etape3 = NmBisYears - 1 ; 
            if((int.Parse(Dates[1]) >= 3)) Etape3 = NmBisYears  ; 
        }


        /* Etape 4 : Ajouté un indicatif par mois ;     J:+0  |  F:+3  |  M:+3  |  A:+6  |  M:+1  |  J:+4  |  J:+6  |  A:+2  |  S:+5  |  O:+0  |  N:+3  |  D+5      */
        if(Dates[1] == "01" || Dates[1] == "10") Etape4 = 0 ;
        if(Dates[1] == "02" || Dates[1] == "03" || Dates[1] == "11") Etape4 = 3 ;
        if(Dates[1] == "04" || Dates[1] == "07") Etape4 = 6 ;
        if(Dates[1] == "05") Etape4 = 1 ;
        if(Dates[1] == "06") Etape4 = 4 ;
        if(Dates[1] == "08") Etape4 = 2 ;
        if(Dates[1] == "09" || Dates[1] == "12") Etape4 = 5 ;


        /* Etape 5 : Ajouté un indicatif par sicèle ;   Si,     Siècles/4=x,00: +6   |   Siècle/4=x,25: +4   |   Siècle/4=x,5: +2  |  Siècle/4=x,75: +0     */
        float Siecle = int.Parse(Dates[2].Remove(Dates[2].Length - 2)); 
        while(Siecle > 3)
        {
            Siecle -= 4 ;
        }

        if(Siecle == 0) Etape5 = 6 ;
        if(Siecle == 1) Etape5 = 4 ;
        if(Siecle == 2) Etape5 = 2 ;
        if(Siecle == 3) Etape5 = 0 ;


        /* Etape 6 : On additionne toute les étapes précédentes */
        Etape6 = Etape1 + Etape2 + Etape3 + Etape4 + Etape5 ; 
        

        /* Etape 7 : On fait le modulo 7 du résulta de l'étape 6, le reste donne le jour :      0:Dimanche  |  1:Lundi  |  2:Mardi  |  3:Mercredi  |  4:Jeudi  |  5:Vendredi  |  6:Samedi */
        int Modulo = Etape6 ;
        while(Modulo >= 7)
        {
            Modulo -= 7 ;
        }

        return Days[Modulo] ;
    }


    string GetPartOfTheDate(string Date, int PartNeed)
    {
        string[] Dates = Date.Split('/') ; //  JJ / MM / YYYY 

        return Dates[PartNeed] ;
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
