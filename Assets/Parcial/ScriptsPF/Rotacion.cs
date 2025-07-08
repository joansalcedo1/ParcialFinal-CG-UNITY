using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidadRotacion = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float rotacionY = velocidadRotacion * Time.deltaTime;

      
        Quaternion rotacion = Quaternion.Euler(0, rotacionY, 0);

        
        transform.rotation *= rotacion;

    }
}
