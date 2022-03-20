using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedSpace : MonoBehaviour,IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject fog;

    public void DoItemInteraction()
    {
        fog.SetActive(false);
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
}
