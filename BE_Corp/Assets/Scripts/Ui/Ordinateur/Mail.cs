using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Mail")]
public class Mail : ScriptableObject
{
    [Header ("Principale Information")]
    public AccountMail Account ;

    public string Objet ;
    public string Description ;

    public string Date ;
    public string Heure ;

    public bool MailLu ;
    public bool IsStoryMail ;


    [Header ("Mail Display")]
    public Sprite BannerMail ;

    [TextArea(5,10)] public string TextMail ;
    public float HeightTextBloc ;
}