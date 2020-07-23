using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс описыающий поведение блоков
public class Bricks : MonoBehaviour
{
    public GameObject brickParticle;

    // Уничтожение блоков при ударе и инстанцирование на их месте частиц
    private void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}