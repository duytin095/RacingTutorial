using UnityEngine.UI;
using UnityEngine;

public class LapTimeManager : MonoBehaviour
{
    public static int minuteCount;
    public static int secondCount;
    public static float miliCount;
    public static string miliDisplay;

    public GameObject minuteBox;
    public GameObject secondBox;
    public GameObject miliBox;


    // Update is called once per frame
    void Update()
    {
        miliCount += Time.deltaTime * 10;
        miliDisplay = miliCount.ToString("0");
        miliBox.GetComponent<Text>().text = "" + miliDisplay;

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
    }
}