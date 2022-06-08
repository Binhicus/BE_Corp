using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject glow, border;
    public Color glowImage, borderImage;
    public Animator animBouton;
    // Start is called before the first frame update
    private void Start()
    {
        borderImage = border.GetComponent<Image>().color;
        glowImage = glow.GetComponent<Image>().color;
    }

    public void AnimOn()
    {

        Debug.Log("dessus");
        /*DOTween.To(x => borderImage.a = x, borderImage.a, 0.75f, 0.3f);
        DOTween.To(x => glowImage.a = x, glowImage.a, 0.75f, 0.3f);        
        border.GetComponent<Image>().color = borderImage;
        glow.GetComponent<Image>().color = glowImage;*/
        animBouton.SetTrigger("Anim On");
    }

    // Update is called once per frame
   public void AnimOff()
    {

        /*Debug.Log("dehors");
        DOTween.To(x => borderImage.a = x, borderImage.a, 0.15f, 0.3f);
        DOTween.To(x => glowImage.a = x, glowImage.a, 0.15f, 0.3f);
        border.GetComponent<Image>().color = borderImage;
        glow.GetComponent<Image>().color = glowImage;*/
        animBouton.SetTrigger("Anim Off");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimOn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AnimOff();
    }
}
