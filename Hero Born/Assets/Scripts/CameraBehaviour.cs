using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 CameraOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform _targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        _targetTransform = GameObject.Find("Player").transform;
    }

    // LateUpdate occurs after the current update and before the next update
    void LateUpdate()
    {
        this.transform.position = _targetTransform
            .TransformPoint(CameraOffset);

        this.transform.LookAt(_targetTransform.position);
    }
}
