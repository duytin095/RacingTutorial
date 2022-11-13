using UnityEngine;

public class ColorHandle : MonoBehaviour
{
    public Material caro;
    public Material yellow;
    public Material blue;
    public Material red;
    public Material defaultColor;
    public GameObject car;
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
    }


    public void YellowButt()
    {
        ChangeColor(yellow);
    }
    public void CaroButt()
    {
        ChangeColor(caro);
    }
    public void BlueButt()
    {
        ChangeColor(blue);
    }
    public void RedButt()
    {
        ChangeColor(red);
    }
    public void DefaultButt()
    {
        ChangeColor(defaultColor);
    }
}
