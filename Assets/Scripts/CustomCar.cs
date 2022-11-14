using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCar : MonoBehaviour
{
    private void Start()
    {
        transform.GetComponent<MeshRenderer>().material = GameManager.Instance.storedColor;
    }
}
