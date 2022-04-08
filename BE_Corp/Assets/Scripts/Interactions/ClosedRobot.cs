using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedRobot : MonoBehaviour,IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject Piles;
    //public GameObject OuverturePorteChambre;
    //public GameObject DetectouvrePorte;
    public void DoItemInteraction()
    {
        PlayerPrefs.SetInt("Piles",1);
        Debug.Log("Je drope les piles normalement");
    }

    // Start is called before the first frame update
    void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Awake()
    {
    }
}
