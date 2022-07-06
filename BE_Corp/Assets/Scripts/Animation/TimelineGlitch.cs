using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineGlitch : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public BlockReference cinematique;
    // Start is called before the first frame update
    void Start()
    {
        StartGlitch();
    }

    public void StartGlitch()
    {
        if (PlayerPrefs.GetInt("Salon Révélé") == 1 && PlayerPrefs.GetInt("Cinématique Salon") == 0)
        {
            //cinematique.Execute();
            playableDirector.enabled = true;
            GlitchyBreak.Instance.GlitchEffectOn();
            Invoke("EndGlitchSalon", 2f);
        }

        if (PlayerPrefs.GetInt("Cuisine Révélée") == 1 && PlayerPrefs.GetInt("Cinématique Salon") == 0)
        {
            //cinematique.Execute();
            playableDirector.enabled = true;
            GlitchyBreak.Instance.GlitchEffectOn();
            Invoke("EndGlitchCuisine", 2f);
        }

    }

    public void EndGlitchSalon()
    {
        GlitchyBreak.Instance.GlitchEffectOff();
        MisAJourEffect.Instance.MiseAJour();
        PlayerPrefs.GetInt("Cinématique Salon", 1);
    }
    public void EndGlitchCuisine()
    {
        GlitchyBreak.Instance.GlitchEffectOff();
        MisAJourEffect.Instance.MiseAJour();
        PlayerPrefs.GetInt("Cinématique Cuisine", 1);
    }
}
