using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Camera cam;

    float axis_X, axis_Z;

    public float speed = 35f;
    public float rotationSpeed = 720;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 right = Vector3.Cross(Vector3.up, cam.transform.forward);
        Vector3 forward = Vector3.Cross(right, Vector3.up);
        Vector3 movement = Vector3.zero;

        movement += right * (axis_X * speed * Time.deltaTime);
        movement += forward * (axis_Z * speed * Time.deltaTime);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnHorizontal(InputValue val)
    {
        axis_X = val.Get<float>();
    }

    void OnVertical(InputValue val)
    {
        axis_Z = val.Get<float>();
    }
}