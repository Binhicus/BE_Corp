using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using UnityEngine.Experiemntal.Rendering.Universal;

public class GlitchyBreak : Singleton<GlitchyBreak>
{
    public bool isOn;
    [SerializeField] ForwardRendererData rendererData;
    [SerializeField] Material glitchEffect;
    [SerializeField] float transitionSpeed = 0.2f;
    [SerializeField] float minValue, maxValue;
    float transition = 0;
    Blit blitFeature;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        RefreshRendererData();
    }

    public void GlitchEffectOn()
    {
        isOn = true;
    }
    public void GlitchEffectOff()
    {
        isOn = false;
    }

    public void RefreshRendererData()
    {
        var blitFeature = rendererData.rendererFeatures.OfType<Blit>().FirstOrDefault();
        blitFeature.settings.blitMaterial = glitchEffect;
        rendererData.SetDirty();
    }

    private void Update()
    {
        if(isOn && transition < 1)
        {
            transition += Time.deltaTime * 1 / transitionSpeed;
            if (transition > 1) transition = 1;
        }
        else if(!isOn && transition > 0)
        {
            transition -= Time.deltaTime * 1 / transitionSpeed;
            if (transition < 0) transition = 0;
        }

        glitchEffect.SetFloat("Vector1_96BFCD79", Mathf.Lerp(minValue, maxValue, transition));
        //glitchEffect.SetFloat("Vector1_96BFCD79", iTween.FloatUpdate(minValue, maxValue, transition));
    }
}
