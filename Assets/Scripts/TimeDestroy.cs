using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс необходимый для удаления созданых частиц со сцены       
public class TimeDestroy : MonoBehaviour
{
    public float destroyTime = 1f;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    
}
   
    