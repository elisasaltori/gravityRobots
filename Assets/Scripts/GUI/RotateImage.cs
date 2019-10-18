using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    Transform obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        obj.Rotate(0, 0, rotationSpeed);
    }
}
