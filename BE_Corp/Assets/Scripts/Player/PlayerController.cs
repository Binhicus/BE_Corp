using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float axis_X, axis_Y;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * axis_X * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * axis_Y * Time.deltaTime);
    }

    void OnHorizontal(InputValue val)
    {
        axis_X = val.Get<float>();
    }

    void OnVertical(InputValue val)
    {
        axis_Y = val.Get<float>();
    }
}
