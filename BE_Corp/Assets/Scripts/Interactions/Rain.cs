using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject FondPluie;
    public AudioSource rainSon;
    private bool Une;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        
    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("Parapluie")==1)
        {
           
            FondPluie.SetActive(true);
            rainSon.Play();
            rainSon.volume=0.2f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Parapluie")==1&&Une==false)
        {
          FondPluie.SetActive(true);
          Une=true;
        }
    }
}
