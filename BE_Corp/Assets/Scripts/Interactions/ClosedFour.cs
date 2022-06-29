using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedFour : MonoBehaviour,IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public Animator test;
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
        PlayerPrefs.SetInt("Four", 1);
        test.SetTrigger("Ouvre");
    }

    public void ItemDropAnim() //////////////
    {

    }

    void Awake()
    {
        test=this.GetComponentInChildren<Animator>();
    }
}
