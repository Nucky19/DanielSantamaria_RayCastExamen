using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public Text cuentaAtras;
    public bool isRayCasting;
    void Update()
    {
        Raycast();
    }

    void Raycast(){
        if(Input.GetButtonDown("Fire1")){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                // Debug.Log(hit.transform.tag);
                if(hit.transform.tag == "Scene1" && !isRayCasting)  StartCoroutine(CuentaAtras("Scene1 1"));
                if(hit.transform.tag == "Scene2" && !isRayCasting)  StartCoroutine(CuentaAtras("Scene1 2"));
                if(hit.transform.tag == "Scene3" && !isRayCasting)  StartCoroutine(CuentaAtras("Scene1 3"));

            };
        }
    }

    IEnumerator CuentaAtras(string Scene){
        isRayCasting=true;
        for (int i = 5; i >= 1; i--){
            cuentaAtras.text= i.ToString();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(Scene);
    }
}
