using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        // Tampilkan dan bebaskan kursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene("Game 1 Scene");
    }
}

