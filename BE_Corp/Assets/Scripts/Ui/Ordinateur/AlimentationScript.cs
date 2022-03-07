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

        StartCoroutine(ComputerLunch());
    }

    IEnumerator ComputerLunch()
    {
        GetComponent<Image>().color = BackgroundOff ;
        yield return new WaitForSeconds(1f);
        LogoWindows.SetActive(true) ;

        yield return new WaitForSeconds(2f);
        GetComponent<Image>().DOColor(BackgroundColor, 0.25f) ;
        LogoWindows.SetActive(false);
        UserAvatar.SetActive(true);
        
        NameComputer.gameObject.SetActive(true);
        InputLogIn.SetActive(true);
    }


    void Update()
    {
        
    }

    public void VerifPassword(string InputReturn)
    {
        if(PassWordRequest.Contains(InputReturn))
        {
            StartCoroutine(UnlockComputer());
        } else {
            InputLogIn.GetComponent<InputField>().text = null ;
            IndiceObj.SetActive(true) ;
        }

    }

    IEnumerator UnlockComputer()
    {
        IndiceObj.SetActive(false);
        InputLogIn.SetActive(false);
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
}
