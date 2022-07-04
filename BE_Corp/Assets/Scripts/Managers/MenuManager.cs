using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject EscargotReward ;
    public Image FadeImage ;

    public ZoomIndiceScript ZIScriptComputer ;

    public TextMeshProUGUI TextTitle ;
    [SerializeField] private AudioSource KeyboardSound ;
    private string TextTitleRef;

    private void Awake() 
    {
        if(PlayerPrefs.GetInt("Escargot") == 0) EscargotReward.SetActive(false);
        else EscargotReward.SetActive(true);

        FadeImage.gameObject.SetActive(true);

        TextTitleRef = TextTitle.text ;
        TextTitle.text = "" ;
    }

    private void Start() 
    {
        StartCoroutine(ShowMenu());
        StartCoroutine(ShowTitle());
    }

    IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(1.1f);
        for (int i = 0; i < TextTitleRef.Length; i++)
        {
            TextTitle.text = TextTitleRef.Remove(i) ;
            PlayKeybordSound();
            yield return new WaitForSeconds(Random.Range(0.05f,0.25f));
        }
        PlayKeybordSound();
        TextTitle.text = TextTitleRef ;
    }

    void PlayKeybordSound()
    {
        KeyboardSound.Stop();
        KeyboardSound.volume = Random.Range(0.4f, 0.5f);
        KeyboardSound.pitch = Random.Range(0.7f, 1.01f);
        KeyboardSound.Play();        
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


    public void DezoomCamera()
    {
        ZIScriptComputer.CloseComputer();


        if(GameObject.FindGameObjectWithTag("Camera Zoom") != null)
        {
            GameObject.FindGameObjectWithTag("Camera Zoom").SetActive(false);
        }

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");

        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = true ;
        }
    }
}
