using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float bossSpeed;
    [SerializeField] private float delay = 2f;

    [SerializeField] private Vector2 rightPoint;
    [SerializeField] private Vector2 leftPoint;
    [SerializeField] private Vector2 downPoint;

    private bool isRight;
    private bool isLeft = true;
    private bool isDown;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPoint, bossSpeed * Time.deltaTime);
        }
       
        if (isLeft)
        {
            transform.position = Vector2.MoveTowards(transform.position, downPoint, bossSpeed * Time.deltaTime);
        }

        if (isDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPoint, bossSpeed * Time.deltaTime);
        }

        if (transform.position.x == rightPoint.x)
        {
            isRight = true;
            isLeft = false;
            isDown = false;
        }

        if (transform.position.x == leftPoint.x)
        {
            isLeft = true;
            isRight = false;
            isDown = false;
        }

        if(transform.position.y == downPoint.y)
        {
            isLeft = false;
            isRight = false;
            isDown = true;
        }

    }

}
