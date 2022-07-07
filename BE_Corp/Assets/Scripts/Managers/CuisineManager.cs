using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuisineManager : MonoBehaviour
{
    public GameObject cuisineHidden, cuisineReveal;
    public TimelineGlitch timeline;
    // Start is called before the first frame update
   void OnEnable()
   {
        CuisineLoader();   
   }

   void Awake()
   {
        //PlayerPrefs.SetInt("Cuisine Révélée",1);
   }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CuisineState()
    {
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 0)
        {
            cuisineReveal.SetActive(false);
            cuisineHidden.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 1 && PlayerPrefs.GetInt("Cinématique Cuisine") == 0)
        {
            timeline.enabled = true;
        }
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 1 && PlayerPrefs.GetInt("Cinématique Cuisine") == 1)
        {
            cuisineReveal.SetActive(true);
            cuisineHidden.SetActive(false);
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
