using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHRotate : MonoBehaviour
{
    [SerializeField] GameObject LHObject;
    [SerializeField] float Speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LHObject.transform.Rotate(0.0f, Speed, 0.0f, Space.World);
    }
}
