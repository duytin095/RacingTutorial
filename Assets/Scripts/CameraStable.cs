using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    [SerializeField]
    private GameObject theCar;
    private float carX, carY, carZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carX = theCar.transform.eulerAngles.x;
        carY = theCar.transform.eulerAngles.y;
        carZ = theCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(carX - carX, carY, carZ);
    }
}
