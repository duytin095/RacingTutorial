using UnityEngine;

public class CustomCar : MonoBehaviour
{
    [SerializeField]
    Material carMaterial;
    [SerializeField]
    Material defaultMaterial;



    private void Start()
    {
        carMaterial = GameManager.Instance.storedColor;

        //Get the last time SAVE COLOR and apply this for the car on the scene
        ChangeMaterial(carMaterial);

        // if can't get the SAVE COLOR
        //type mismatch??
        if (carMaterial == null) // material dont display right when push git??? or turn off the lap??? dont know why 
        {
            ChangeMaterial(defaultMaterial);
            ColorHandle.Instance.ChangeColor(defaultMaterial);
            Debug.Log("fuck you");
        }

        

    }
    private void ChangeMaterial(Material material)
    {
        transform.GetComponent<MeshRenderer>().material = material;
        //Debug.Log("uh hu ye");
    }
}
