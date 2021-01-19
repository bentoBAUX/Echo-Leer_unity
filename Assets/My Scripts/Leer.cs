using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class Leer : MonoBehaviour
{
    public Material LeerSkybox;
    public Material NormalSkybox;
    public GameObject Leer_GO;
    public GameObject Leer_Point;
    public Transform cam;

    public AudioClip leeringNoise;

    public bool looking;
    public bool Leering = false;

    public float speed;

    public Vector3 LeerPoint_Pos;
    UnityEngine.Quaternion cam_prevPos;

    private void Start()
    {
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogColor = Color.black;
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0;

        cam_prevPos = cam.rotation;   
    }
    void Update()
    { 
        Leer_Point.transform.position = this.cam.TransformPoint(LeerPoint_Pos);

        if (Input.GetButtonDown("Fire"))
        {

            Debug.Log("Clicked");
            Leer_GO.transform.parent = null;
            Leer_Point.SetActive(false);
            StartCoroutine("moveToPoint");
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public IEnumerator moveToPoint()
    {
        while(Leer_GO.transform.position != Leer_Point.transform.position)
        {
            Leer_GO.transform.position = Vector3.MoveTowards(Leer_GO.transform.position, Leer_Point.transform.position, speed);
            yield return null;
        }
        StartCoroutine("LeerActivate");
    }


    IEnumerator LeerActivate()
    {
        float duration = 10f;
        float normalizedTime = 0f;
        while (normalizedTime <= 1f)
        {
            Leering = true;
            
            if (looking)
            {
                RenderSettings.skybox = LeerSkybox;
                //fade in fog
                StartCoroutine("FadeIn");
            }
            else
            {
                RenderSettings.fogDensity = 0f;
                RenderSettings.skybox = NormalSkybox;
                //fade out fog
                
            }
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        RenderSettings.skybox = NormalSkybox;
        RenderSettings.fog = false;
        Leer_GO.SetActive(false);
        Leering = false;
    }

    IEnumerator FadeIn()
    {
        float num = 0f;
        while (num <= 0.2f)
        {
            num += 0.01f;
            Debug.Log(num);
            RenderSettings.fogDensity = num;
            yield return new WaitForSeconds(0.0025f);
        }
    }


}
