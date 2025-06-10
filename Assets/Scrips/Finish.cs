using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void Start()
    {
        // Tampilkan dan bebaskan kursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("MainMenuUI");
    }

}
