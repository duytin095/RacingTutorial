using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    private Vector3 camPos;

    // Update is called once per frame
    void Update()
    {
        camPos = new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.position.z);
        transform.position = camPos;
    }
}
