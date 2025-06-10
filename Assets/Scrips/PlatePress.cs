using UnityEngine;
using DG.Tweening;

public class PlatePress : MonoBehaviour
{
    public string TriggerTag = "Player";

    public Transform TargetTween;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(TriggerTag)){
            StartTween(-0.1f, 3);
        }
    }  
    
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(TriggerTag)){
            StartTween(1, 9);
        }
    }

    private void StartTween(float yTarget, float duration){
        TargetTween.DOScaleY(yTarget, duration);
    }
}
