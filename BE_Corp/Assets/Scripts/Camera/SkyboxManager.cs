using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkyboxManager : MonoBehaviour
{   [Header("A tweaker")]
    public Material skyboxMat;
    public float tweenFloat;

    [Header("Références")]
    public Material entreeMat;
    public Material salonMat;
    public Material cuisineMat;
    public Material roomMat;

    private void Start()
    {
        RenderSettings.skybox = skyboxMat;
        EntreeSB();
    }
    public void SalonSB()
    {
        skyboxMat.DOColor(salonMat.GetColor("_SunDiscColor"), "_SunDiscColor", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_SunDiscMultiplier"), "_SunDiscMultiplier", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_SunDiscExponent"), "_SunDiscExponent", tweenFloat);

        skyboxMat.DOColor(salonMat.GetColor("_SunHaloColor"), "_SunHaloColor", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_SunHaloExponent"), "_SunHaloExponent", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_SunHaloContribution"), "_SunHaloContribution", tweenFloat);

        skyboxMat.DOColor(salonMat.GetColor("_HorizonLineColor"), "_HorizonLineColor", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_HorizonLineExponent"), "_HorizonLineExponent", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_HorizonLineContribution"), "_HorizonLineContribution", tweenFloat);

        skyboxMat.DOColor(salonMat.GetColor("_SkyGradientTop"), "_SkyGradientTop", tweenFloat);
        skyboxMat.DOColor(salonMat.GetColor("_SkyGradientBottom"), "_SkyGradientBottom", tweenFloat);
        skyboxMat.DOFloat(salonMat.GetFloat("_SkyGradientExponent"), "_SkyGradientExponent", tweenFloat);
    }

    public void EntreeSB()
    {
        skyboxMat.DOColor(entreeMat.GetColor("_SunDiscColor"), "_SunDiscColor", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_SunDiscMultiplier"), "_SunDiscMultiplier", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_SunDiscExponent"), "_SunDiscExponent", tweenFloat);

        skyboxMat.DOColor(entreeMat.GetColor("_SunHaloColor"), "_SunHaloColor", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_SunHaloExponent"), "_SunHaloExponent", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_SunHaloContribution"), "_SunHaloContribution", tweenFloat);

        skyboxMat.DOColor(entreeMat.GetColor("_HorizonLineColor"), "_HorizonLineColor", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_HorizonLineExponent"), "_HorizonLineExponent", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_HorizonLineContribution"), "_HorizonLineContribution", tweenFloat);

        skyboxMat.DOColor(entreeMat.GetColor("_SkyGradientTop"), "_SkyGradientTop", tweenFloat);
        skyboxMat.DOColor(entreeMat.GetColor("_SkyGradientBottom"), "_SkyGradientBottom", tweenFloat);
        skyboxMat.DOFloat(entreeMat.GetFloat("_SkyGradientExponent"), "_SkyGradientExponent", tweenFloat);
    }

    public void CuisineSB()
    {
        skyboxMat.DOColor(cuisineMat.GetColor("_SunDiscColor"), "_SunDiscColor", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_SunDiscMultiplier"), "_SunDiscMultiplier", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_SunDiscExponent"), "_SunDiscExponent", tweenFloat);

        skyboxMat.DOColor(cuisineMat.GetColor("_SunHaloColor"), "_SunHaloColor", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_SunHaloExponent"), "_SunHaloExponent", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_SunHaloContribution"), "_SunHaloContribution", tweenFloat);

        skyboxMat.DOColor(cuisineMat.GetColor("_HorizonLineColor"), "_HorizonLineColor", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_HorizonLineExponent"), "_HorizonLineExponent", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_HorizonLineContribution"), "_HorizonLineContribution", tweenFloat);

        skyboxMat.DOColor(cuisineMat.GetColor("_SkyGradientTop"), "_SkyGradientTop", tweenFloat);
        skyboxMat.DOColor(cuisineMat.GetColor("_SkyGradientBottom"), "_SkyGradientBottom", tweenFloat);
        skyboxMat.DOFloat(cuisineMat.GetFloat("_SkyGradientExponent"), "_SkyGradientExponent", tweenFloat);
    }

    public void RoomSB()
    {
        skyboxMat.DOColor(roomMat.GetColor("_SunDiscColor"), "_SunDiscColor", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_SunDiscMultiplier"), "_SunDiscMultiplier", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_SunDiscExponent"), "_SunDiscExponent", tweenFloat);

        skyboxMat.DOColor(roomMat.GetColor("_SunHaloColor"), "_SunHaloColor", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_SunHaloExponent"), "_SunHaloExponent", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_SunHaloContribution"), "_SunHaloContribution", tweenFloat);

        skyboxMat.DOColor(roomMat.GetColor("_HorizonLineColor"), "_HorizonLineColor", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_HorizonLineExponent"), "_HorizonLineExponent", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_HorizonLineContribution"), "_HorizonLineContribution", tweenFloat);

        skyboxMat.DOColor(roomMat.GetColor("_SkyGradientTop"), "_SkyGradientTop", tweenFloat);
        skyboxMat.DOColor(roomMat.GetColor("_SkyGradientBottom"), "_SkyGradientBottom", tweenFloat);
        skyboxMat.DOFloat(roomMat.GetFloat("_SkyGradientExponent"), "_SkyGradientExponent", tweenFloat);
    }

}
