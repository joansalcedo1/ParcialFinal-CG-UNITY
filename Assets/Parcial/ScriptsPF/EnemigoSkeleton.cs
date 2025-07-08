using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSkeleton : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion rotacion;
    public float grado;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Erika");
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }

    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            anim.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;

            }

            switch (rutina)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 306);
                    rotacion = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var mirarPos = target.transform.position - transform.position;
            mirarPos.y = 0;
            var rotation1 = Quaternion.LookRotation(mirarPos);
            transform.rotation=Quaternion.RotateTowards(transform.rotation, rotation1,2);
            anim.SetBool("walk", false);

            anim.SetBool("run", true);
            transform.Translate(Vector3.forward*2*Time.deltaTime);
        }
    }
}
