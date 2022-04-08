using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedSpace : MonoBehaviour,IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject fog;
    public GameObject OuverturePorteChambre;
    public void DoItemInteraction()
    {
        fog.SetActive(false);
        PlayerPrefs.SetInt("Fog", 1);
        OuverturePorteChambre.GetComponent<BoxCollider>().enabled=true;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        fog = GameObject.Find("Gray Volume Fog");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Awake()
    {
        fog = GameObject.Find("Gray Volume Fog");
        OuverturePorteChambre=GameObject.Find("Ouverture");

        if(PlayerPrefs.GetInt("fog")==1)
        {
            fog.SetActive(false);
        }
    }
}
