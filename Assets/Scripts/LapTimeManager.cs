using UnityEngine.UI;
using UnityEngine;
using System;

public class LapTimeManager : MonoBehaviour
{
    //Present time
    public static int minuteCount;
    public static int secondCount;
    public static float miliCount;

    public static float rawTime;

    //Best time
    public static int minuteCountBest;
    public static int secondCountBest;
    public static float miliCountBest;


    public static string miliDisplay;

    [SerializeField]
    private GameObject presentTimeBox;
    [SerializeField]
    private GameObject bestTimeBox;
    [SerializeField]
    private GameObject finishTimeBox;




    private void Start()
    {
        if (GameManager.Instance == null)
        {
            return;
        }
        UpdateBestScore();
    }

    void Update()
    {
        rawTime += Time.deltaTime * 10;
        miliCount += Time.deltaTime * 10;
        miliDisplay = miliCount.ToString("F0");

        if(finishTimeBox != null)
        {
            finishTimeBox.GetComponent<Text>().text = 
                minuteCount.ToString("00") + ":" + 
                secondCount + ":" + 
                miliCount.ToString("0.0");
        }

        presentTimeBox.GetComponent<Text>().text =
            minuteCount.ToString("00") + ":" +
            secondCount.ToString("00") + ":" +
            miliCount.ToString("0.0");

        if (miliCount >= 10)
        {
            miliCount = 0;
            secondCount += 1;
        }

        if (secondCount >= 60)
        {
            secondCount = 0;
            minuteCount += 1;
        }
    }


    public void UpdateBestScore()
    {
        GameManager.Instance.LoadPlayerInfo();
        bestTimeBox.GetComponent<Text>().text = 
            minuteCountBest.ToString("00") + ":" +
            secondCountBest.ToString("00") + ":" + 
            miliCountBest.ToString("0.0");
    }
}
