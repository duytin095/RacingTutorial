using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] GameObject rain;

    private void Start()
    {
        if (rain.activeInHierarchy)
        {
            rain.SetActive(false);
        }
        StartCoroutine(Rain());
    }

    public IEnumerator Rain()
    {
        
        yield return new WaitForSeconds(7f);
        rain.SetActive(true);
        yield return new WaitForSeconds(15f);
        rain.SetActive(false);
        
        StartCoroutine(Rain());
    }
}
