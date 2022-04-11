using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedRadio : MonoBehaviour,IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public bool AntenneOk;
    public GameObject Antenne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoItemInteraction()
    {
        Antenne.SetActive(true);
        PlayerPrefs.SetInt("Antenne", 1);
        
    }


    void Awake()
    {
        Antenne = GameObject.Find("Antenne Radio");

        if(PlayerPrefs.GetInt("Antenne")==0)
        {
            Antenne.SetActive(false);
        }
    }
}
