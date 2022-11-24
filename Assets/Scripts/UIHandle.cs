using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandle : MonoBehaviour
{
    private const string MAIN_MENU = "Menu";
    private const string CUSTOM_CAR = "CustomCar";
    private const string TRACK_SELECTION = "TrackSelect";
    private const string CREDIT_SCENE = "Credit";

    [SerializeField] private GameObject pausePanel;
    private bool isGamePause = false;

    private void Start()
    {
        if(pausePanel != null)
        {
            if (pausePanel.activeInHierarchy)
            {
                pausePanel.SetActive(false);
            }
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
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
        SceneManager.LoadScene(MAIN_MENU);
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
        if (!isGamePause)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            isGamePause = true;
            pausePanel.SetActive(true);
        }
    }

    public void UnPauseGame()
    {
        if (isGamePause)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            isGamePause = false;
            pausePanel.SetActive(false);
        } 
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UnPauseGame();
    }
}