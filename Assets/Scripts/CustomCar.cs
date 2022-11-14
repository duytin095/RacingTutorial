using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCar : MonoBehaviour
{
    private void Start()
    {
        ColorHandle.Instance.LoadColor();
        transform.GetComponent<MeshRenderer>().material = GameManager.Instance.storedColor;
    }
}
