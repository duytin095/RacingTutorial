using UnityEngine;

public class OpenGarageButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        UIHandle.Instance.OpenGaragePanel();
    }
}
