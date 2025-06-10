using UnityEngine;
using DG.Tweening;

public class AnimationStair : MonoBehaviour
{
    // Lama animasi dalam detik
    public float duration = 6f;

    // Posisi Y target (bisa diubah dari Inspector juga)
    public float targetY = -11.73f;

    // Fungsi untuk memulai animasi tangga turun
    public void StartAnimationStair()
    {
        if (transform == null)
        {
            Debug.LogWarning("Transform tidak ditemukan!");
            return;
        }

        Vector3 targetPosition = new Vector3(transform.localPosition.x, targetY, transform.localPosition.z);
        transform.DOLocalMove(targetPosition, duration);
    }
}

