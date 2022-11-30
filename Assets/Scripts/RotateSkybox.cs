using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed); 
    }
}
