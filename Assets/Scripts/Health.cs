using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 10;
    [SerializeField] ParticleSystem hitEffect;

    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;
    [SerializeField] bool applySoundDamage;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damage = collision.GetComponent<Damage>();

        if(damage != null)
        {
            TakeDamage(damage.GetDamage());
            PlayHitEffect();
            PlayAudio();
            damage.Hit();
            ShakeCamera();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
            Destroy(gameObject);
        }
        else if(isPlayer)
        {
            Destroy(gameObject);
            levelManager.LoadGameOver();
        }

    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void PlayAudio()
    {
        if(audioPlayer != null && applySoundDamage)
        {
            audioPlayer.PlayDamageClip();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
