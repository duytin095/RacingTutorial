using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCar : MonoBehaviour
{
    private float speed = 20;
    private bool isRotate = false;
    void Start()
    {
        Invoke("EnableRotation", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateTheCar();
    }

    private void RotateTheCar()
    {
        if(isRotate)
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void EnableRotation()
    {
        isRotate = true;
    }
}
