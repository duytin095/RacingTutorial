using UnityEngine;
using System.IO;

public class ColorHandle : MonoBehaviour
{
    public Material caro;
    public Material yellow;
    public Material blue;
    public Material red;
    public Material defaultColor;
    public GameObject car;

    private Material presentColor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeColor(Material color)
    {
        car.GetComponent<MeshRenderer>().material = color;
        presentColor = color;
    }


    public void YellowButt()
    {
        ChangeColor(yellow);
        SaveCarProperty();
    }
    public void CaroButt()
    {
        ChangeColor(caro);
        SaveCarProperty();
    }
    public void BlueButt()
    {
        ChangeColor(blue);
        SaveCarProperty();
    }
    public void RedButt()
    {
        ChangeColor(red);
        SaveCarProperty();
    }
    public void DefaultButt()
    {
        ChangeColor(defaultColor);
        SaveCarProperty();
    }



    public void SaveCarProperty()
    {
        Car carData = new Car();

        carData.color = presentColor;
        string json = JsonUtility.ToJson(carData);
        File.WriteAllText(Application.persistentDataPath + "/CarProperty.json", json);
        Debug.Log("Save Car Property");
    }
}



[SerializeField]
public class Car{
    public Material color;

    
}
