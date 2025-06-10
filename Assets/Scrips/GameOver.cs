using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string saveKey = "IsJumpscareKey";
    public string timerKey = "SavedTimer";
    public Transform jumpScareCheckpoint;
    public Transform player;
    public TMP_Text gameOverText;
    public string gameOverMassage = "Kamu Tertangkap";
    public string finishMessage = "Kamu Berhasil Lolos";

    [Header("Debug")]
    public int IsJumpscareSaved = 0;

    private void Awake()
    {
        IsJumpscareSaved = PlayerPrefs.GetInt(saveKey);

        if (IsJumpscareSaved == 1)
        {
            player.position = jumpScareCheckpoint.position;
            player.rotation = jumpScareCheckpoint.rotation;
        }
    }

    public void StartJumpscare()
    {
        StartCoroutine(StartJumpscareDelay());
    }

    IEnumerator StartJumpscareDelay()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = gameOverMassage;

        IsJumpscareSaved = 1;
        PlayerPrefs.SetInt(saveKey, IsJumpscareSaved);

        // Simpan sisa waktu dari CountdownTimer
        CountdownTimer timer = FindObjectOfType<CountdownTimer>();
        if (timer != null)
        {
            PlayerPrefs.SetFloat(timerKey, timer.GetTimeLeft());
        }

        PlayerPrefs.Save();
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [ContextMenu("Reset Jumpscare Save")]
    public void ResetJumpscareSave()
    {
        PlayerPrefs.DeleteKey(saveKey);
        PlayerPrefs.DeleteKey(timerKey);
    }

    public void StartFinish()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = finishMessage;

        // Hentikan timer
        CountdownTimer timer = FindObjectOfType<CountdownTimer>();
        if (timer != null)
        {
            timer.StopTimer();
        }

        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Epilogue");
    }
}