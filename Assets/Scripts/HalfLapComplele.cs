using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfLapComplele : MonoBehaviour
{
    public GameObject lapCompleteTrigger;
    public GameObject halfPointTrigger;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lapCompleteTrigger.SetActive(true);
            halfPointTrigger.SetActive(false);

        }
    }
}
