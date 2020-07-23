using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game Mananger
// Класс описывающий управление уровнем в целом
public class GM : MonoBehaviour
{
    public static float delayTime = 0.5f; //  Время задержки после уничтожения всех блоков
    public int bricks = 20; // начальное количество блоков
    public GameObject bricksPrefab;
    public GameObject paddle;
    public static GM instance = null; 

    private GameObject clonePaddle;
    
    //Реализация синглтона
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(instance);
        Setup();
    }
    //Метод инициализирующий плтаформу с привязанной к ней шайбой и блоки
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }
    
    // Метод возвращающий шайбу на поле 
    public void ResetBall()
    {
        Destroy(clonePaddle);
        Destroy(GameObject.Find("Ball"));
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }

    // Проверка на разрушение всех блоков ( на завершение игры)
    void checkGameOver()
    {
        if (bricks < 1)
        {
            Time.timeScale = .25f; // замедление игры при разрушении всех блоков
            Invoke("Reset", delayTime);
        }


    }

    // Метод подгружающий заново сцену 
    void Reset()
    {
        Time.timeScale = 1f; // востановление нормального течения игрового времени
        SceneManager.LoadScene("SampleScene");
    }
    
    // Метод уменьшающий количество блоков с проверкой на конец игры
    public void DestroyBrick()
    {
        bricks--;
        checkGameOver();
    }
}
