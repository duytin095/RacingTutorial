using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandle : MonoBehaviour
{
    public static UIHandle Instance;

    private const string CUSTOM_CAR = "CustomCar";
    private const string TRACK_SELECTION = "TrackSelect";
    private const string CREDIT_SCENE = "Credit";


    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject garagePanel;
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private GameObject cashText;

    [SerializeField] private GameObject earningValue;
    [SerializeField] private LapComplete lapCompleteTrigger;

    private int confirmPanelChildPosition = 1;
    private bool isGamePause = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (finishPanel != null) // Make sure that FINISH PANEL is exist and not open at start
        {
            if (finishPanel.activeInHierarchy)
            {
                finishPanel.SetActive(false);
            }
        }

        if (pausePanel != null) // Make sure that PAUSE PANEL is exist and not open at start
        {
            if (pausePanel.activeInHierarchy)
            {
                pausePanel.SetActive(false);
            }
        }

        if (cashText != null) // Make sure that CASH TEXT is exist in hierarchy
        {
            cashText.GetComponent<Text>().text = "Cash: " + GameManager.Instance.storedCash.ToString() + "$";
        }

        if (garagePanel != null) // Make sure that GARAGE PANEL is exist and not open at start
        {
            if (garagePanel.activeInHierarchy)
            {
                garagePanel.SetActive(false);
            }
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause && !ConfirmPanel().activeInHierarchy) // Make sure ConfirmPanel was closed
            {
                UnPauseGame();
            }
            else if(!isGamePause)
            {
                PauseGame();
            }
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        UnPauseGame();
        
    }

    public void SelectTrack()
    {
        SceneManager.LoadScene(TRACK_SELECTION);
    }
    public void BackToMainMenu()
    {
        ResetCountingTime();
        SceneManager.LoadScene(CUSTOM_CAR);
        UnPauseGame();

    }
    public void CustomCarScene()
    {
        SceneManager.LoadScene(CUSTOM_CAR);

    }
    public void CreditScene()
    {
        SceneManager.LoadScene(CREDIT_SCENE);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit(); //original code to quit Unity player
#endif
    }

    public void PauseGame()
    {
        if (!isGamePause && pausePanel != null)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            isGamePause = true;
            pausePanel.SetActive(true);
        }
    }

    public void UnPauseGame()
    {
        if (isGamePause && pausePanel != null)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            isGamePause = false;
            pausePanel.SetActive(false);
            
        } 
    }

    public void Restart()
    {
        ResetCountingTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UnPauseGame();
    }

    public void OpenConfirmMenu()
    {
        if (!ConfirmPanel().activeInHierarchy)
        {
            ConfirmPanel().SetActive(true);
        }
    }

    public void CloseConfirmMenu()
    {
        if (ConfirmPanel().activeInHierarchy)
        {
            ConfirmPanel().SetActive(false);
        }
    }

    private GameObject ConfirmPanel()
    {
        GameObject confirmPanel;
        confirmPanel = pausePanel.transform.GetChild(confirmPanelChildPosition).gameObject;
        return confirmPanel;
    }

    public void OpenFinishPanel()
    {
        if(finishPanel != null) // Make sure that FINISH PANEL exist in hierarchy
        {
            if (!finishPanel.activeInHierarchy) // Checking if that FINISH PANEL not active in hierarchy
            {
                finishPanel.SetActive(true);
            }

            if(earningValue != null)
            {
                earningValue.GetComponent<Text>().text = "" + GameManager.Instance.cashValue + "$";
            }
        }
    }

    public void OpenGaragePanel()
    {
        if(!garagePanel.activeInHierarchy && garagePanel != null)
            garagePanel.SetActive(true);
        if (menuPanel.activeInHierarchy && menuPanel != null)
            menuPanel.SetActive(false);

    }
    public void CloseGaragePanel()
    {
        if(garagePanel.activeInHierarchy && garagePanel != null)
            garagePanel.SetActive(false);
        if (!menuPanel.activeInHierarchy && menuPanel != null)
            menuPanel.SetActive(true);
    }

    private void ResetCountingTime()
    {
        if (lapCompleteTrigger != null)
        {
            lapCompleteTrigger.ResetTime();
        }
    }
}