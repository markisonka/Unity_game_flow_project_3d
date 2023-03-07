using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Если касаемся препятствия, перезапускаем сцену
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("Main");//TO DO: менюшку
        }
    }
}
