using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float storedRawTime;
    private int storedMunite;
    private int stroredSecond;
    private float storedMilisecond;



    //Color Hadler
    public Material storedColor;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public void SavePlayerInfo()
    {
        SaveData saveData = new SaveData();

        if(storedRawTime == 0)
        {
            storedRawTime = LapTimeManager.rawTime;
            storedMunite = LapTimeManager.minuteCount;
            stroredSecond = LapTimeManager.secondCount;
            storedMilisecond = LapTimeManager.miliCount;
            
        }
        if(storedRawTime > LapTimeManager.rawTime)
        {
            storedRawTime = LapTimeManager.rawTime;
            storedMunite = LapTimeManager.minuteCount;
            stroredSecond = LapTimeManager.secondCount;
            storedMilisecond = LapTimeManager.miliCount;
        }

        saveData.rawTime = storedRawTime;
        saveData.minute = storedMunite;
        saveData.second = stroredSecond;
        saveData.milisecond = storedMilisecond;


        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/racingTutorialSaveFile.json", json);

        Debug.Log("SAVING HERE!");
        Debug.Log(saveData.minute + "/"+saveData.second + "/" + saveData.milisecond + "RAW TIME:>>>> " + saveData.rawTime);

    }

    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/racingTutorialSaveFile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            //Get data
            LapTimeManager.minuteCountBest = saveData.minute;
            LapTimeManager.secondCountBest = saveData.second;
            LapTimeManager.miliCountBest = saveData.milisecond;

            Debug.Log("LOADING HERE");
            Debug.Log(saveData.minute + "/" +    saveData.second + "/" +saveData.milisecond);
            Debug.Log("RAW TIME: " + saveData.rawTime);
            storedRawTime = saveData.rawTime;
            storedMunite = saveData.minute;
            stroredSecond = saveData.second;
            storedMilisecond = saveData.milisecond;

        }

    }

    public void LoadColor()
    {

        string path = Application.persistentDataPath + "/CarProperty.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Car data = JsonUtility.FromJson<Car>(json);

            storedColor = data.color;
            Debug.Log("Load Color here");
            GameManager.Instance.storedColor = storedColor;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int minute;
        public int second;
        public float milisecond;
        public float rawTime;
    }



}
