using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public int CurrentAge = 18;
    public int AddedAge = 1;

    // Start is called before the first frame update
    void Start()
    {
        ComputeAge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }
}
