using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCar : MonoBehaviour
{
    private void OnMouseDown()
    {
        UIHandle.Instance.OpenGaragePanel();
    }
}
