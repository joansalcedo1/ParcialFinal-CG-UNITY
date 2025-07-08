using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public  GameObject personaje;
    public GameObject ProccesingWater;
    public GameObject ProccesingNormal;
    //public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            ProccesingWater.SetActive(true);
            ProccesingNormal.SetActive(false);
            //rb.GetComponent<Rigidbody>().useGravity = false;
            //Debug.Log("Estoy dentro del agua");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ProccesingWater.SetActive(false);
            ProccesingNormal.SetActive(true);
            //rb.GetComponent<Rigidbody>().useGravity = true;
            //Debug.Log("Sali del agua");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
