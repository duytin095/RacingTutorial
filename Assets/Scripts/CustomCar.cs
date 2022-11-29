using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCar : MonoBehaviour
{
    [SerializeField]
    Material carMaterial;
    private void Start()
    {
        carMaterial = GameManager.Instance.storedColor;
        transform.GetComponent<MeshRenderer>().material = carMaterial;
    }
}
