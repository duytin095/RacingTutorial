using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //LoadPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int minute;
        public int second;
        public float milisecond;
    }

    public void SavePlayerInfo()
    {
        SaveData saveData = new SaveData();

        LapTimeManager.minuteCountBest = LapTimeManager.minuteCount;
        LapTimeManager.secondCountBest = LapTimeManager.secondCount;
        LapTimeManager.miliCountBest = LapTimeManager.miliCount;

        saveData.minute = LapTimeManager.minuteCountBest;
        saveData.second = LapTimeManager.secondCountBest;
        saveData.milisecond = LapTimeManager.miliCountBest;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/racingTutorialSaveFile.json", json);

        Debug.Log("SAVING HERE!");
        Debug.Log(saveData.minute + "/"+saveData.second + "/" + saveData.milisecond);

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

            //Display data in game scene
            

        }
    }
}
