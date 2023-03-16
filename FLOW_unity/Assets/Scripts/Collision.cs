using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject LevelControl;
    private void OnTriggerEnter(Collider other)
    {
        //Если касаемся препятствия, перезапускаем сцену
        if(other.tag == "Obstacle")
        {
            LevelControl.GetComponent<EndRunSequence>().enabled = true;
            //SceneManager.LoadScene("Main");
        }
    }
}
