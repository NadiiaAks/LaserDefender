using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float bossSpeed;
    [SerializeField] private float delay = 2f;

    [SerializeField] private Vector3 rightPoint;
    [SerializeField] private Vector3 leftPoint;

    private Vector3 move;

    void Update()
    {
        Move();
    }

    private void Move()
    {


    }

}
