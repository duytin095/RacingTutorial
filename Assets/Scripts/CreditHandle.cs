using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditHandle : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;

    private void Start()
    {
        Invoke("BackToMain", 25f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMain();
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("CustomCar");
    }
}
