using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class WallTrigger : MonoBehaviour
{
    //bool hitting = false;
    public KickBall ballInt;
    public AudioSource ballImpact;

    private void Awake()
    {
        ballInt = GameObject.Find("Soccer Ball").GetComponent<KickBall>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ballon")
        {
            //ballInt.hitting = true;
            ballImpact.Play();
            ballInt.Consequence();
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ballon")
        {
            hitting = false;
        }
    }*/
}
