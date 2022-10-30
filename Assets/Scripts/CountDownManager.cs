using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownManager : MonoBehaviour
{
    public AudioSource getReadyAudio;
    public AudioSource goAudio;
    public LapTimeManager lapTimeManager;

    [SerializeField] private PrometeoCarController prometeoCarController;
    public GameObject countDown;

    public Follower[] follower;

    void Start()
    {
        lapTimeManager = FindObjectOfType<LapTimeManager>();
        StartCoroutine(Counting());
        follower = FindObjectsOfType<Follower>();
    }

    IEnumerator Counting()
    {
        yield return new WaitForSeconds(0.5f);
        countDown.GetComponent<Text>().text = "3";
        getReadyAudio.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "2";
        getReadyAudio.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "1";
        getReadyAudio.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        goAudio.Play();
        lapTimeManager.enabled = true; //start countinng lap time
        prometeoCarController.enabled = true; //player can move from here
        foreach (var item in follower)
        {
            item.enabled = true; //oponent can move from here
        }


    }
}
