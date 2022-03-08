using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class AlimentationScript : MonoBehaviour
{
    [SerializeField] private ComputerNavigationScript ComputerInformation ; 
    [SerializeField] private GameObject LogoWindows ;
    [SerializeField] private GameObject FondVeille ;    
    [SerializeField] private TextMeshProUGUI HeureEcranVeille ;
    [SerializeField] private TextMeshProUGUI DateEcranVeille ;
    [SerializeField] private GameObject UserAvatar ;
    [SerializeField] private TextMeshProUGUI NameComputer ;
    [SerializeField] private GameObject InputLogIn ;
    [SerializeField] private GameObject IndiceObj ;
    [SerializeField] private GameObject WelcomeObj ;

    [SerializeField] private List<string> PassWordRequest ;
    [SerializeField] private string PassWordHelp = "Il dort tout le temps" ;

    public Color BackgroundOff ;
    public Color BackgroundColor ;
    // Start is called before the first frame update
    void Start()
    {
        UserAvatar.GetComponent<Image>().sprite = ComputerInformation.Avatar ;
        NameComputer.text = ComputerInformation.ComputerName ;

        HeureEcranVeille.text = ComputerInformation.Heure ;
        DateEcranVeille.text = GetDayOfTheDate(ComputerInformation.Date) + ", " + GetPartOfTheDate(ComputerInformation.Date, 0) + " " + GetPartOfTheDate(ComputerInformation.Date, 1);

        StartCoroutine(ComputerLunch());
    }

    string GetDayOfTheDate(string Date)
    {
        //string DaysReturn = "" ;

        string[] Days = new string[] {"Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi"} ;
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
        string[] Month = new string[] {"janvier", "février", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre"," octobre", "novembre", "décembre"};

        if(PartNeed != 1) return Dates[PartNeed];
        else return Month[PartNeed] ;
    }


    IEnumerator ComputerLunch()
    {
        StartComputer();
        yield return new WaitForSeconds(1f);
        LogoWindows.SetActive(true) ;
        // Loader

        yield return new WaitForSeconds(5f);
        // Ecran de veille
        GetComponent<Image>().color = BackgroundColor ;
        StartCoroutine(FadeInFondVeille());

    }


    IEnumerator FadeInFondVeille()
    {
        FondVeille.GetComponent<Image>().DOFade(0, 0f);
        FondVeille.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        FondVeille.GetComponent<Image>().DOFade(1, 1f);
        ShowLogin();
    }

    void ShowLogin()
    {
        LogoWindows.SetActive(false);
        UserAvatar.SetActive(true);
        
        NameComputer.gameObject.SetActive(true);
        InputLogIn.SetActive(true);        
    }

    public void VerifPassword(string InputReturn)
    {
        if(PassWordRequest.Contains(InputReturn))
        {
            StartCoroutine(UnlockComputer());
            // Loader
        } else {
            InputLogIn.GetComponent<InputField>().text = null ;
            IndiceObj.SetActive(true) ;
        }

    }

    IEnumerator UnlockComputer()
    {
        IndiceObj.SetActive(false);
        InputLogIn.SetActive(false);
        InputLogIn.GetComponent<InputField>().text = null ;
        WelcomeObj.SetActive(true);

        yield return new WaitForSeconds(3f);
        GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().enabled = false ;

        LogoWindows.SetActive(false);
        UserAvatar.SetActive(false);
        NameComputer.gameObject.SetActive(false);
        IndiceObj.SetActive(false);
        InputLogIn.SetActive(false);
        WelcomeObj.SetActive(false);

        GetComponent<CanvasGroup>().alpha = 1 ;
    }


    void StartComputer()
    {
        GetComponent<Image>().enabled = true ;
        GetComponent<Image>().color = BackgroundOff ;
        LogoWindows.SetActive(false);
        FondVeille.SetActive(false);
        UserAvatar.SetActive(false);
        NameComputer.gameObject.SetActive(false);
        IndiceObj.SetActive(false);
        InputLogIn.SetActive(false);
        WelcomeObj.SetActive(false);
    }

    public void RestartComputer()
    {
        ComputerInformation.CloseMail();
        ComputerInformation.OpenLunchWindow();

        GetComponent<Image>().enabled = true ;
        GetComponent<CanvasGroup>().alpha = 0 ;

        StartCoroutine(ComputerShutdown());
    }

    IEnumerator ComputerShutdown()
    {
        StartComputer();
        yield return new WaitForSeconds(0.5f);
        GetComponent<CanvasGroup>().DOFade(1, 0.25f);

        // Loader

        yield return new WaitForSeconds(3f);
        StartCoroutine(ComputerLunch());
    }

}

