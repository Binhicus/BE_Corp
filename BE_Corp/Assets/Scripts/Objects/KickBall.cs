using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : ClickableObject
{
    public float hauteur = 1.0f;
    public float allant = 3.0f;
    public Rigidbody rb;
    public Collider ball;
    public VaseSwitch vaseSwitch;
    public SplCameraShake shaker;
    bool hitting = false;
    public Texture2D cursor;
    public Texture2D regularCursor;

    
    void OnEnable()
    {
        ball = gameObject.GetComponent<SphereCollider>();
        shaker = GameObject.Find("CameraShaker").GetComponent<SplCameraShake>();
        rb = GetComponent<Rigidbody>();

        if (PlayerPrefs.GetInt("VaseAndKey") <= 1)
        {
            vaseSwitch = GameObject.Find("Switch").GetComponent<VaseSwitch>();            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kicked()
    {
        rb.AddForce(allant, hauteur, 0, ForceMode.Impulse);
    }

    public void Consequence()
    {      
       shaker.Shaker();
       vaseSwitch.KicksCount();
       Debug.Log("ouille ouille je suis le mur trigger et j'ai mal" + gameObject);
    }
}
