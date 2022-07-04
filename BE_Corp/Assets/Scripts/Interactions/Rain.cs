using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public List<GameObject> Lapluie = new List <GameObject>();
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
            for(int i = 0; i < Lapluie.Count; i++)
          {
            Lapluie[i].SetActive(true);
            rainSon.Play();
            rainSon.volume=0.2f;
          }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Parapluie")==1)
        {
            for(int i = 0; i < Lapluie.Count; i++)
          {
            Lapluie[i].SetActive(true);
            Une=false;
          }
        }
    }
}
