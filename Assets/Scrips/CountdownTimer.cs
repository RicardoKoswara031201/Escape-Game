using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 180f; // 5 menit
    private float timeLeft;
    public TextMeshProUGUI timerText;
    private bool isTimeRunning = true;
    public TMP_Text textTimer;
    private string timerKey = "SavedTimer";

    public string dead = "Waktu habis! Player mati.";

    void Start()
    {
        // Cek apakah ada waktu tersimpan
        if (PlayerPrefs.HasKey(timerKey))
        {
            timeLeft = PlayerPrefs.GetFloat(timerKey);
            PlayerPrefs.DeleteKey(timerKey); // hanya sekali pakai
        }
        else
        {
            timeLeft = totalTime;
        }
    }

    void Update()
    {
        if (isTimeRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                isTimeRunning = false;
                GameOver();
            }

            DisplayTime(timeLeft);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        textTimer.gameObject.SetActive(true);
        textTimer.text = dead;

        StartCoroutine(RestartDelay());
    }

    private IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenuUI");
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void StopTimer()
    {
        isTimeRunning = false;
    }
}
