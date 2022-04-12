using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    //bool hitting = false;
    public KickBall ballInt;
    private void Awake()
    {
        ballInt = GameObject.Find("Soccer Ball").GetComponent<KickBall>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ballon")
        {
            //ballInt.hitting = true;
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
