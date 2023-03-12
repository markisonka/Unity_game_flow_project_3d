using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public AudioSource startFX;

    void Start()
    {
        startFX.Play();
    }

}
