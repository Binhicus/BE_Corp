using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuisineManager : MonoBehaviour
{
    public GameObject radio, gateau, microOndes, cuisinePartUne, cuisinePartDeux,cuisinePartTrois;
    public GameObject Holo1,Holo2;
    // Start is called before the first frame update
   void OnEnable()
   {
        CuisineLoader();   
   }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CuisineState()
    {
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 0)
        {
            cuisinePartUne.SetActive(true);
            Holo1.SetActive(true);
            cuisinePartDeux.SetActive(false);
            cuisinePartTrois.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 1)
        {
            Holo1.SetActive(false);
            cuisinePartUne.SetActive(true);
            cuisinePartDeux.SetActive(true);
             cuisinePartTrois.SetActive(false);
        }
       /* if (PlayerPrefs.GetInt("Cuisine Révélée") == 2)
        {
            Holo1.SetActive(false);
            Holo2.SetActive(false);
            cuisinePartUne.SetActive(true);
            cuisinePartDeux.SetActive(true);
             cuisinePartTrois.SetActive(true);
        }*/
    }
     public void CleObtenue()
     {
        PlayerPrefs.SetInt("Key", 1 );
     }

    public void CuisineLoader()
    {
        CuisineState();
    }
}
