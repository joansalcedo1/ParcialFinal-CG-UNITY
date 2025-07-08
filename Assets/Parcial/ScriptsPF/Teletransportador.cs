using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teletransportador : MonoBehaviour
{
    public GameObject jugador;
    public GameObject transportador;
    public GameObject transportadorB;
    public GameObject transportadorC;
    public GameObject transportadorD;
    int n;
    // Start is called before the first frame update
    void Start()
    {
        n = 1;
    }
 
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();

        // Generamos un número aleatorio entre 1 y 4
        n = random.Next(1, 5);

        if (n == 1)
        {
            jugador.transform.position = new Vector3(transportadorB.transform.localPosition.x, transportadorB.transform.localPosition.y, transportadorB.transform.localPosition.z);
        }
        else if (n == 2)
        {
            jugador.transform.position = new Vector3(transportadorC.transform.localPosition.x, transportadorC.transform.localPosition.y, transportadorC.transform.localPosition.z);
        }
        else if (n == 3)
        {
            jugador.transform.position = new Vector3(transportadorD.transform.localPosition.x, transportadorD.transform.localPosition.y, transportadorD.transform.localPosition.z);
        }
        else 
        {
            jugador.transform.position = new Vector3(transportador.transform.localPosition.x, transportador.transform.localPosition.y, transportador.transform.localPosition.z);
        }
    }


}
