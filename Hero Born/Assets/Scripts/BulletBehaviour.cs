using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float OnScreenDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, OnScreenDelay);
    }
}
