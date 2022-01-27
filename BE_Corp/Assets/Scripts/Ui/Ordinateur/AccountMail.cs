using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AccountMail")]
public class AccountMail : ScriptableObject
{
    public string NameAccount ;

    [Space(10)]
    public Sprite LogoContact ;
   // public string Initiale { get => Initiale; set => Initiale = GetInitial(NameAccount); }
    public Color AccountColor ;

/*
    string GetInitial(string Name)
    {
        string InitialFound = "" ;

        string[] Names = Name.Split(' ') ;

        foreach(string NamesFound in Names)
        {
            InitialFound = InitialFound + NamesFound.Substring(0,1);
        }

        return InitialFound ; 
    }*/
}