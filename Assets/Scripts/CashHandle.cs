using UnityEngine;
using UnityEngine.UI;

public class CashHandle : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Text>().text = "Cash: " + GameManager.Instance.storedCash.ToString() + "$";
    }

}
