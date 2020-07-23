using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Класс описывающий поведение запрещенной зоны для шайбы
public class DeadZone : MonoBehaviour
{
    // Возврат шайбы после пересечения с красной линией
    private void OnTriggerEnter(Collider col)
    {
        GM.instance.ResetBall();
    }
    
}
