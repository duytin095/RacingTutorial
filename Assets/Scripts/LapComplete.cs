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
    public float lapTotal = 2;
    public Text lapCountDisplay;


    public GameObject playerFollowCam;
    public GameObject player;
    public GameObject fisnishLineCam;
    private bool isCrossFinishLine = false;

    public AudioSource completeSound, carEngineSound, carFX, bgMusic;

    private Follower[] follower;


    [SerializeField] private UIHandle uIHandle;

    private void Start()
    {
        follower = FindObjectsOfType<Follower>();
    }

    private void Update()
    {
        if(isCrossFinishLine)
            fisnishLineCam.transform.RotateAround(player.transform.position, Vector3.up, 30 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Saving time
            if (GameManager.Instance == null)
                return;

            uIHandle.OpenFinishPanel();
            uIHandle.CancelInvoke();
            GameManager.Instance.SavePlayerInfo();
            GameManager.Instance.SaveCash();

            lapTimeManager.UpdateBestScore();

            ResetTime();

            halfPointTrigger.SetActive(true);
            lapCompleteTrigger.SetActive(false);

            if (lapCount < lapTotal)
            {
                lapCount++;

            }
            lapCountDisplay.text = lapCount.ToString();

            // FINISH LINE
            if(lapCount == lapTotal)
            {
                lapCompleteTrigger.SetActive(true);
                playerFollowCam.SetActive(false);
                fisnishLineCam.SetActive(true);
                isCrossFinishLine = true;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                completeSound.Play(); // play complete sound
                carEngineSound.Pause(); // diable car sound
                player.GetComponent<PrometeoCarController>().enabled = false; // disable player's controller
                carFX.enabled = false; // disable car sound
                bgMusic.Pause(); // backgound music too
                this.transform.GetComponent<BoxCollider>().enabled = false; // the race finish now, so there is nothing to tracking anymore

                lapTimeManager.enabled = false; // stop couting time
                // disable opponent movement
                foreach (var opponent in follower)
                {
                    opponent.enabled = false;
                }
            }
        }

    }

    public void ResetTime()
    {
        LapTimeManager.miliCount = 0;
        LapTimeManager.minuteCount = 0;
        LapTimeManager.secondCount = 0;
        LapTimeManager.rawTime = 0;
    }
}
