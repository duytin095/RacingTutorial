using UnityEngine;
using System.IO;

public class ColorHandle : MonoBehaviour
{
    public GameObject car;
    public Material pickingColor;
    public void ChangeColor(Material color)
    {
        car.GetComponent<MeshRenderer>().material = color;
        pickingColor = color;
        SaveCarProperty();
    }

    public void SaveCarProperty()
    {
        Car carData = new Car();

        carData.color = pickingColor;
        string json = JsonUtility.ToJson(carData);
        File.WriteAllText(Application.persistentDataPath + "/CarProperty.json", json);
        Debug.Log("Save Car Property");
        GameManager.Instance.storedColor = pickingColor;
    }
}

[SerializeField]
public class Car{
    public Material color;  
}
