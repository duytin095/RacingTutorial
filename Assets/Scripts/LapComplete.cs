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
    public float lapTotal = 1;
    public Text lapCountDisplay;


    public GameObject playerFollowCam;
    public GameObject player;
    public GameObject fisnishLineCam;
    private bool isCrossFinishLine = false;

    public GameObject carEngineSound, carFX, bgMusic;
    public AudioSource completeSound;

    private Follower[] follower;

    private void Start()
    {
        follower = FindObjectsOfType<Follower>();
    }

    private void Update()
    {
        if(isCrossFinishLine)
            fisnishLineCam.transform.RotateAround(player.transform.position, Vector3.up, 100 * Time.deltaTime);
    }
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

            if (lapCount < lapTotal)
            {
                lapCount++;

            }
            lapCountDisplay.text = lapCount.ToString();

            if(lapCount == lapTotal)
            {
                lapCompleteTrigger.SetActive(true);
                playerFollowCam.SetActive(false);
                fisnishLineCam.SetActive(true);
                isCrossFinishLine = true;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero; //stop player's car
                player.GetComponent<PrometeoCarController>().enabled = false; // disable player's controller
                completeSound.Play(); // play complete sound
                carEngineSound.SetActive(false); // diable car sound
                carFX.SetActive(false); // disable car sound
                bgMusic.SetActive(false); // backgound music too
                this.transform.GetComponent<BoxCollider>().enabled = false; // the race finish now, so there is nothing to tracking anymore


                // disable opponent movement
                foreach (var opponent in follower)
                {
                    opponent.enabled = false;
                }
            }
        }

    }
}
