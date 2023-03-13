using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject var2;
    private void OnTriggerEnter(Collider other)
    {
        //Если касаемся препятствия, перезапускаем сцену
        if(other.tag == "Obstacle")
        {
            var2.GetComponent<EndRunSequence>().enabled = true;
            //SceneManager.LoadScene("Main");//TO DO: менюшку
        }
    }
}
