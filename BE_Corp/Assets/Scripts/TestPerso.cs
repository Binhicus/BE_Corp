using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPerso : MonoBehaviour
{
    Rigidbody rb;
    
    public float AxisX;
    public float AxisY;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Speed * AxisX * Time.deltaTime);
        transform.Translate(Vector3.forward * Speed * AxisY * Time.deltaTime);
    }

    private void Awake() {

    }


    public void OnHorizontal(InputValue val)
    {
        AxisX= val.Get<float>();
    }

    public void OnVertical(InputValue val)
    {
        AxisY = val.Get<float>();
    }

}
