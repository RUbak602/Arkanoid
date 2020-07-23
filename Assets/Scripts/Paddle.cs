using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс описывающий поведение платформы
public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 0.3f;
    public const float yInitial = -9.5f; // уровень появления платформы по оси Y
    public const float wallPos = 7.5f;
    private Vector3 playerPos = new Vector3(0f, yInitial, 0f);
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal")) * paddleSpeed;
        playerPos = new Vector3(Mathf.Clamp(xPos, -wallPos, wallPos), yInitial, 0f); // Ограничение движение платформы
        transform.position = playerPos;
    } 
}
