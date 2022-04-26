using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class GlitchyBreak : Singleton<GlitchyBreak>
{
    [SerializeField] ForwardRendererData rendererData;
    [SerializeField] Material glitchEffect;
    [SerializeField] float transition = 0;
    [SerializeField] bool inAnimation, isDone;
    [SerializeField] float minValue, maxValue;

    protected override void Awake()
    {
        base.Awake();
    }
    public void GlitchEffectOn()
    {
        inAnimation = true;
        DOTween.Kill(transition);
        //transition = glitchEffect.GetFloat("Vector1_96BFCD79");
        var blitFeature = rendererData.rendererFeatures.OfType<UnityEngine.Experiemntal.Rendering.Universal.Blit>().FirstOrDefault();
        blitFeature.settings.blitMaterial = glitchEffect;
        //transition = Mathf.Lerp(transition, maxValue, 1.2f);
        DOTween.To(x => transition = x, transition, maxValue, 1.2f);
        //glitchEffect.SetFloat("Vector1_96BFCD79", 0.25f);
        StopAllCoroutines();
        StartCoroutine(WaitAndSetBool(1.2f, true));
        //transition = 0.25f;
        rendererData.SetDirty();
    }
    public void GlitchEffectOff()
    {
        inAnimation = true;
        DOTween.Kill(transition);
        //transition = glitchEffect.GetFloat("Vector1_96BFCD79");
        var blitFeature = rendererData.rendererFeatures.OfType<UnityEngine.Experiemntal.Rendering.Universal.Blit>().FirstOrDefault();
        blitFeature.settings.blitMaterial = glitchEffect;
        transition = Mathf.Lerp(transition, minValue, 0.3f);
        DOTween.To(y => transition = y, transition, minValue, 0.3f);        
        glitchEffect.SetFloat("Vector1_96BFCD79", 0);
        StopAllCoroutines();
        StartCoroutine(WaitAndSetBool(0.15f, false));
       
        //transition = 0f;
        rendererData.SetDirty(); 
    }

    private void Update()
    {
        if (inAnimation)
        {
            glitchEffect.SetFloat("Vector1_96BFCD79", transition);  
        }      
        else if(isDone)
        {
            glitchEffect.SetFloat("Vector1_96BFCD79", maxValue);            
        }
        else
        {
            glitchEffect.SetFloat("Vector1_96BFCD79", minValue);
            transition = 0f;
        }
    }

    IEnumerator WaitAndSetBool(float duration, bool isOver)
    {
        yield return new WaitForSeconds(duration);
        isDone = isOver;
        inAnimation = false;
    }
    /*
    IEnumerator ActivateTransition()
    {
        float elapsed = 0.0f;
        while (elapsed < hoveringTime)
        {
            transition = Mathf.Lerp(transition, maxValue, elapsed / hoveringTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transition = maxValue;
    }
    
    IEnumerator DeactivateTransition()
    {
        float elapsed = 0.0f;
        while (elapsed < hoveringTime)
        {
            transition = Mathf.Lerp(transition, minValue, elapsed / leaveTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transition = minValue;
    }*/
}
