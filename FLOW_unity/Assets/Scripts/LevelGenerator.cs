using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Используемые тайлы
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject StartTile;

    private float Index = 0;
    public List<GameObject> InstancedObjects = new List<GameObject>();//Список с тайлами

    private void Start()
    {
        //Создаем несколько начальных тайлов (чтобы на старте не умирать от препятствий)
        GameObject StartPlane1 = Instantiate(StartTile, transform);
        InstancedObjects.Add(StartPlane1);
        StartPlane1.transform.position = new Vector3(7, 0, 0);
        
        GameObject StartPlane2 = Instantiate(StartTile, transform);
        InstancedObjects.Add(StartPlane2);
        StartPlane2.transform.position = new Vector3(-1, 0, 0);
       
        GameObject StartPlane3 = Instantiate(StartTile, transform);
        InstancedObjects.Add(StartPlane3);
        StartPlane3.transform.position = new Vector3(-9, 0, 0);
       
        /*GameObject StartPlane4 = Instantiate(StartTile, transform);
        StartPlane4.transform.position = new Vector3(-17, 0, 0);
       
        GameObject StartPlane5 = Instantiate(StartTile, transform);
        StartPlane5.transform.position = new Vector3(-25, 0, 0);*/
    }

    private void Update()
    {
        //Движение тайлов (ось Х)
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0); 

        if(transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, 2);

            //Создаем рандомный тайл 1 или 2
            if(RandomInt1 == 1)
            {
                GameObject TempTile1 = Instantiate(Tile1, transform);
                InstancedObjects.Add(TempTile1);
                TempTile1.transform.position = new Vector3(-16, 0, 0);
            }
            else if(RandomInt1 == 0)
            {
                GameObject TempTile1 = Instantiate(Tile2, transform);
                InstancedObjects.Add(TempTile1);
                TempTile1.transform.position = new Vector3(-16, 0, 0);
            }

            int RandomInt2 = Random.Range(0, 2);

            //Создаем еще один рандомный тайл
            if (RandomInt2 == 1)
            {
                GameObject TempTile2 = Instantiate(Tile1, transform);
                InstancedObjects.Add(TempTile2);
                TempTile2.transform.position = new Vector3(-24, 0, 0);
            }
            else if(RandomInt2 == 0)
            {
                GameObject TempTile2 = Instantiate(Tile2, transform);
                InstancedObjects.Add(TempTile2);
                TempTile2.transform.position = new Vector3(-24, 0, 0);
            }

            Index = Index + 15.95f;
        }

        if (InstancedObjects.Count > 5)//Если тайлов больше 5, то уничтожаем нулевой
        {
            Destroy(InstancedObjects[0]);
            InstancedObjects.RemoveAt(0);
        }
    }
}
