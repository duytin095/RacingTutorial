using UnityEngine.UI;
using UnityEngine;

public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrigger;
    public GameObject halfPointTrigger;

    public GameObject minuteDisplay;
    public GameObject secondDisplay;
    public GameObject miliDisplay;

    public GameObject lapTimeBox;



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (LapTimeManager.secondCount <= 9)
            {
                secondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.secondCount + ".";

            }
            else
            {
                secondDisplay.GetComponent<Text>().text = "" + LapTimeManager.secondCount + ".";
            }

            if (LapTimeManager.minuteCount <= 9)
            {
                minuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.minuteCount + ".";
            }
            else
            {
                minuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.minuteCount + ".";

            }

            miliDisplay.GetComponent<Text>().text = "" + LapTimeManager.miliCount;

            LapTimeManager.miliCount = 0;
            LapTimeManager.minuteCount = 0;
            LapTimeManager.secondCount = 0;

            halfPointTrigger.SetActive(true);
            lapCompleteTrigger.SetActive(false);
    }

}
}
