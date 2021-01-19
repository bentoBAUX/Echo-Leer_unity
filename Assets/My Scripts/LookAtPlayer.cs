using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform cameraMain;
    public Leer leerScript;
    void Update()
    {

        if (GetComponent<Renderer>().isVisible)
        {
            leerScript.looking = true;
        }
        else
        {
            leerScript.looking = false;
        }
    }
}
