using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 rawInput;
    private Vector2 minBouns;
    Vector2 maxBouns;

    private void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBouns = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBouns = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));  
    }

    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBouns.x, maxBouns.x);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBouns.y, maxBouns.y);
        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
