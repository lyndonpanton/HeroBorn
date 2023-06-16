using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _verticalInput;
    private float _horizontalInput;

    private Rigidbody _rb;

    void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            _rb = GetComponent<Rigidbody>();
        } else
        {
            this.AddComponent<Rigidbody>();
            _rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _verticalInput = Input.GetAxis("Vertical") * MoveSpeed;

        //this.transform.Translate(
        //    _verticalInput * Time.deltaTime * Vector3.forward
        //);

        //this.transform.Rotate(
        //    _horizontalInput * Time.deltaTime * Vector3.up
        //);
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _horizontalInput;

        Quaternion angleRotation = Quaternion.Euler(
            rotation * Time.fixedDeltaTime
        );

        _rb.MovePosition(
            this.transform.position
            + (this.transform.forward * _verticalInput * Time.fixedDeltaTime)
        );

        // Any physics- or Rigidbody-related code always goes inside the FixedUpdate
        // method, rather than Update or the other MonoBehavior methods
        _rb.MoveRotation(
            _rb.rotation * angleRotation
        );
    }
}
