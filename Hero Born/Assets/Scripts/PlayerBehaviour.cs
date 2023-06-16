using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _verticalInput;
    private float _horizontalInput;

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _verticalInput = Input.GetAxis("Vertical") * MoveSpeed;

        this.transform.Translate(
            _verticalInput * Time.deltaTime * Vector3.forward
        );

        this.transform.Rotate(
            _horizontalInput * Time.deltaTime * Vector3.up
        );
    }
}
