using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrigger;
    public GameObject halfPointTrigger;

    public GameObject minuteDisplay;
    public GameObject secondDisplay;
    public GameObject miliDisplay;
    

    public GameObject lapTimeBox;

    public LapTimeManager lapTimeManager;

    public float lapCount = 0;
    public Text lapCountDisplay;



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Saving time
            if (GameManager.Instance == null)
                return;

            GameManager.Instance.SavePlayerInfo();
            lapTimeManager.UpdateBestScore();

            LapTimeManager.miliCount = 0;
            LapTimeManager.minuteCount = 0;
            LapTimeManager.secondCount = 0;
            LapTimeManager.rawTime = 0;

            halfPointTrigger.SetActive(true);
            lapCompleteTrigger.SetActive(false);

            lapCount++;
            lapCountDisplay.text = lapCount.ToString();
        }

    }
}
