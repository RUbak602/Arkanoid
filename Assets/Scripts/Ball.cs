using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс описывающий поведение шара
public class Ball : MonoBehaviour
{
    public float ballInitialVlocity = 600f;
    public float accelerateFactor = 2f;

    private bool ballInGame = false;
    private Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    
    void Update()
    {
        // Пуск шайбы в поле на "пробел"
        if (Input.GetButtonDown("Jump") && (ballInGame == false))
        {
            transform.parent = null;
            ballInGame = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVlocity, ballInitialVlocity, 0f));
        }
    }

    // Ускорение шайбы при ударе о боковые стены в направлении, равному отраженному от стены вектору скорости 
    private void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.name == "WallLeft") || (col.gameObject.name == "WallRight"))
            rb.AddForce(-Vector3.Reflect(rb.velocity, col.GetContact(0).normal) * accelerateFactor); 
    }
}
