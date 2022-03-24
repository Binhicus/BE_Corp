using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedSpace : MonoBehaviour,IHasItemInteraction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject fog;
    public GameManager gameManager;

    public void DoItemInteraction()
    {
        fog.SetActive(false);
        gameManager.TenebreOk();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        fog = GameObject.Find("Gray Volume Fog");
        gameManager = GameObject.Find("Game Manager Save").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        gameManager = GameObject.Find("Game Manager Save").GetComponent<GameManager>();
    }
}
