using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour, IClicked
{
    private KickBall kickBall;
    public string nomDuBallon;

    private void OnEnable()
    {
        kickBall = GameObject.Find(nomDuBallon).GetComponent<KickBall>();
    }
    public void OnClickAction()
    {
        kickBall.Kicked();
    }
}
