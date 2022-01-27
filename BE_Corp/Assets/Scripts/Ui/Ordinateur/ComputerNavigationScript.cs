using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;

public class ComputerNavigationScript : MonoBehaviour
{
    public string Date ;
    public string Heure ;
    public ContainerMailScript InformationMail ;
    public GameObject MailPastille ;
    public Transform MailStateBar ;

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
}
