using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTaille : MonoBehaviour
{
        public bool Go;
     
     
        // Use this for initialization
        void Start ()
        {
       
        }
     
        // Update is called once per frame
        void Update ()
        {
     
     
            if (Go) 
            {
                transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale * 1.25f, Time.deltaTime * 10);
            }
     
     
     
        }

        }

