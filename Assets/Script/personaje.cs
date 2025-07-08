using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class personaje : MonoBehaviour
{


    // Start is called before the first frame update
    public float velocidadMovimiento = 15f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto;
    public bool puedoSaltar;
    public bool puedoAgacharme;
    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;
    public float velocidadIncial;
    public float velocidadAgachado;
    public float velocidadCorrer;
    public GameObject luces;
    bool lucesPrendidas;
    //public bool correr;

    void Start()
    {
        lucesPrendidas=true;
        anim = GetComponent<Animator>();
        puedoSaltar = false;
        puedoAgacharme = false;
        fuerzaSalto = 10f;
        //correr= false;
        velocidadIncial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        velocidadCorrer = velocidadMovimiento * 2.0f;
    }

    private void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

    }
    // Update is called once per frame
    void Update()
    {
        ApagarLuces();
        
        //logica para correr
        if (Input.GetKey(KeyCode.LeftShift) && !estoyAgachado && puedoSaltar)
        {
            Invoke("velocidadPacorrer", 0.25f);
            if (y > 0)
            {
                anim.SetBool("correr", true);
            }
            else
            {
                anim.SetBool("correr", false);
            }


        }
        else
        {
            anim.SetBool("correr", false);
            if (estoyAgachado)
            {
                velocidadMovimiento = velocidadAgachado;
            }
            else if (puedoSaltar)
            {
                velocidadMovimiento = velocidadIncial;
            }
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        //Debug.Log(y);
        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        Debug.Log(velocidadMovimiento);

        //logica par saltar
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);


            }
            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            estoyCayendo();

        }

        //logica para hacer el emote
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetBool("bailar", true);
            Invoke("dejardeBailar", 1f);
        }



        //logica para agacharse
        if (Input.GetKey(KeyCode.LeftControl))
        {
            puedoAgacharme = true;
            if (puedoAgacharme)
            {
                colAgachado.enabled = true;
                colParado.enabled = false;
                cabeza.SetActive(true);
                estoyAgachado = true;

                anim.SetBool("agacharse", true);

            }
        }
        else
        {
            if (logicaCabeza.contadorDeColision <= 0)
            {
                puedoAgacharme = false;
                anim.SetBool("agacharse", false);


                colParado.enabled = true;
                cabeza.SetActive(false);
                colAgachado.enabled = false;
                estoyAgachado = false;

            }
        }


    }

    public void velocidadPacorrer()
    {
        velocidadMovimiento = velocidadCorrer;
    }
    public void dejardeBailar()
    {
        anim.SetBool("bailar", false);
    }
    public void estoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }
    public void ApagarLuces()
    {
        if (lucesPrendidas)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lucesPrendidas = false;
                luces.SetActive(false);

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lucesPrendidas = true;
                luces.SetActive(true);
            }
        }
      }
}

