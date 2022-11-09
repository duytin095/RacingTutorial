using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandle : MonoBehaviour
{
    private const string MAIN_MENU = "Menu";
    private const string TRACK_SELECTION = "TrackSelect";



    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectTrack()
    {
        SceneManager.LoadScene(TRACK_SELECTION);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);

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
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}