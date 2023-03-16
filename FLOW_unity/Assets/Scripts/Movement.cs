using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform Player;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    private bool up = false;

    public Material[] mat_sky;

    public AudioSource cat;
    public AudioClip jumpSound;
    private void Start()
    {
        cat = GetComponent<AudioSource>();
        Player = GetComponent<Transform>();
        RenderSettings.skybox=mat_sky[Random.Range(0 , 5)];//Создать случайно небо
    }

    private void Update()
    {
        //Движение персонажа, 3 линии
        //Если линия 3 занята, то меняем позицию вправо на центральную линию
        if(Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        //Если линия 1 занята, то меняем позицию влево на центральную линию
        else if(Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        //Перемещение со 2ой (центральной) линии на правую линию
        else if(Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        //Перемещение со 2ой (центральной) линии на левую линию
        else if (Lane2 == true && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }



        #region ChangeBools
        //Меняем bool линий в зависимости от инпута игрока
        //Если свайп вправо и линия 3 свободна, а линия 1 занята
        if (SwipeManager.swipeRight == true && Lane3 == false && Lane1 == true)
        {
            //То теперь линия 2 занята, линия 1 и 3 свободны
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        //Если свайп влево и линия 2 занята и позиция игрока слева или по центру
        else if (SwipeManager.swipeLeft == true  && Lane2 == true && Player.position.z <= 0.2f)
        {
            //То теперь линия 1 занята, линия 2 и 3 свободны
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        //Если свайп вправо и линия 2 занята и позиция игрока слева или по центру
        else if (SwipeManager.swipeRight == true && Lane2 == true && Player.position.z >= -0.2f)
        {
            //То теперь линия 3 занята, линия 1 и 2 свободны
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        //Если свайп влево и линия 1 свободна, а линия 3 занята
        else if (SwipeManager.swipeLeft == true && Lane1 == false && Lane3 == true)
        {
            //То теперь линия 2 занята, линия 1 и 3 свободны
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        #endregion

       
        //Если свайп вверх и игрок на земле (позиция Y<=0)
        if (SwipeManager.swipeUp == true && Player.position.y <= 0f && up ==false)
        {
            cat.PlayOneShot(jumpSound);
            up = true; //движение вверх = True
        }
        //Если движение вверх и не достиг предельной высоты
        if(up == true && Player.position.y <= 1.8f)
        { 
            Player.position += new Vector3(0, +5.0f * Time.deltaTime , 0); //Игрок летит вверх (увеличиваем позицию по оси Y)
        }
        else if (Player.position.y > 0f) //Иначе (игрок уже достиг предельной высоты) если высота > 0
        {
           up = false; //Движение вверх = False
           Player.position += new Vector3(0, -5.0f * Time.deltaTime , 0);//Игрок летит вниз (уменьшаем позицию по оси Y)
        }
        else if(Player.position.y < 0f) //Если (позиция Y<=0)
        {
           Player.position += new Vector3(0, 0 , 0);//Больше не меняем позицию игрока 
        }


        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 5.0f); //Вращение неба

        
        
    }
}
