using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range (0f, 1f)] float volumeShooting = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float volumeDamage = 1f;

    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, volumeShooting);
        }
    }

    public void PlayDamageClip()
    {
        if(damageClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, volumeDamage);
        }
    }
}
