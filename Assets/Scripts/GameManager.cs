using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float storedRawTime;

    public int storedMunite;
    public int stroredSecond;
    public float storedMilisecond;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //LoadPlayerInfo();
    }

    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int minute;
        public int second;
        public float milisecond;
        public float rawTime;
    }

    public void SavePlayerInfo()
    {
        SaveData saveData = new SaveData();

        //LapTimeManager.minuteCountBest = LapTimeManager.minuteCount;
        //LapTimeManager.secondCountBest = LapTimeManager.secondCount;
        //LapTimeManager.miliCountBest = LapTimeManager.miliCount;

        //saveData.minute = LapTimeManager.minuteCountBest;
        //saveData.second = LapTimeManager.secondCountBest;
        //saveData.milisecond = LapTimeManager.miliCountBest;

        if(storedRawTime == 0)
        {
            //saveData.rawTime = LapTimeManager.rawTime;
            storedRawTime = LapTimeManager.rawTime;
            storedMunite = LapTimeManager.minuteCount;
            stroredSecond = LapTimeManager.secondCount;
            storedMilisecond = LapTimeManager.miliCount;

            /*
            saveData.minute = LapTimeManager.minuteCount;
            saveData.second = LapTimeManager.secondCount;
            saveData.milisecond = LapTimeManager.miliCount;
            */
            
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


            //Display data in game scene
            

        }
    }
}
