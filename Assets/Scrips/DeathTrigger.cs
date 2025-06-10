using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public TMP_Text deathText;

    public string deathMassage = "Nob You Dead !!!";

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            deathText.gameObject.SetActive(true);
            deathText.text = deathMassage;

            StartCoroutine(RestartDelay());
        }
    }

    private IEnumerator RestartDelay(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenuUI");
    }
}
