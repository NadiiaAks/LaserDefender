using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFire;

    Coroutine firingCoroutine;
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFire && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFire && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
