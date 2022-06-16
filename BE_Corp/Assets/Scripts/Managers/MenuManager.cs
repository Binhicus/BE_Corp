using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public GameObject EscargotReward ;
    public Image FadeImage ;

    private void Awake() 
    {
        if(PlayerPrefs.GetInt("Escargot") == 0) EscargotReward.SetActive(false);
        else EscargotReward.SetActive(true);

        FadeImage.gameObject.SetActive(true);
    }

    private void Start() 
    {
        StartCoroutine(ShowMenu());
    }

    IEnumerator ShowMenu()
    {

        yield return new WaitForSeconds(0.5f);
        FadeImage.DOFade(0,1f);
        yield return new WaitForSeconds(1f);
        FadeImage.raycastTarget = false ;
    }

    public void QuitGame()
    {
        FadeImage.gameObject.SetActive(true);
        FadeImage.raycastTarget = true ;
        FadeImage.DOFade(1f, 0.5f);
        StartCoroutine(DelayBeforeQuit());
    }

    IEnumerator DelayBeforeQuit()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
