using UnityEngine.UI;
using UnityEngine;
using System;

public class LapTimeManager : MonoBehaviour
{
    //Present time
    public static int minuteCount;
    public static int secondCount;
    public static float miliCount;

    //Best time
    public static int minuteCountBest;
    public static int secondCountBest;
    public static float miliCountBest;


    public static string miliDisplay;

    public GameObject minuteBox;
    public GameObject secondBox;
    public GameObject miliBox;

    public GameObject minuteBoxBest;
    public GameObject secondBoxBest;
    public GameObject miliBoxBest;
    private void Start()
    {
        if (GameManager.Instance == null)
        {

            return;
        }
        GameManager.Instance.LoadPlayerInfo();
        minuteBoxBest.GetComponent<Text>().text = minuteCountBest.ToString() + ":";
        secondBoxBest.GetComponent<Text>().text = secondCountBest.ToString() + ".";
        miliBoxBest.GetComponent<Text>().text = miliCountBest.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        miliCount += Time.deltaTime * 10;
        miliDisplay = miliCount.ToString("F0");

        if (miliCount >= 10)
        {
            miliCount = 0;
            secondCount += 1;

        }

        if (secondCount <= 9)
        {
            secondBox.GetComponent<Text>().text = "0" + secondCount + ".";

        }
        else
        {
            secondBox.GetComponent<Text>().text = "" + secondCount + ".";

        }


        if (secondCount >= 60)
        {
            secondCount = 0;
            minuteCount += 1;

        }

        if (minuteCount <= 9)
        {
            minuteBox.GetComponent<Text>().text = "0" + minuteCount + ":";
        }
        else
        {
            minuteBox.GetComponent<Text>().text = "" + minuteCount + ":";
        }

        miliBox.GetComponent<Text>().text = "" + miliDisplay;
    }
}
