using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
     public bool estaVivo = true;
    [SerializeField] private int ouro;
    [SerializeField] private int vida;
    [SerializeField] private int forcaPulo;
    [SerializeField] private float velocidade;
    [SerializeField] private bool temChave;
    [SerializeField] private bool pegando;
    [SerializeField] private bool podePegar;
    [SerializeField] private List<GameObject> inventario = new List<GameObject>();
    private Rigidbody rb;
    private bool estaPulando;
    private Vector3 angleRotation;
    
    public TextMeshProUGUI Pontos;
    private List<string> listaAvisos = new List<string>();
    public int pontos;
    public Jogo diretor;
    

    // Start is called before the first frame update
    void Start()
    {
        ouro = 0;
        temChave = false;
        pegando = false;
        podePegar = false;
        angleRotation = new Vector3(0, 90, 0);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       
        Pontos = GameObject.FindGameObjectWithTag("Ouro").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        TurnAround();

        if (Input.GetKeyDown(KeyCode.E) && podePegar)
        {
            animator.SetTrigger("Pegando");
            pegando = true;
        }

        //Andar
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar", true);
            animator.SetBool("AndarPraTras", false);
            Walk();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarPraTras", true);
            animator.SetBool("Andar", false);
            Walk();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Andar", true);
        }
        else
        {
            animator.SetBool("Andar", false);
            animator.SetBool("AndarPraTras", false);
        }

        //Evitar o bug da movimento
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Andar", false);
            animator.SetBool("AndarPraTras", false);
        }

        //Pulo
        if (Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            animator.SetTrigger("Pular");
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Ataque");
        }

        //Correr
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Correndo", true);
            Walk(8);
        }
        else
        {
            animator.SetBool("Correndo", false);
        }

        if (!estaVivo)
        {
            animator.SetTrigger("EstaVivo");
            estaVivo = true;
        }
    }

    private void Walk(float velo = 1)
    {
        if ((velo == 1))
        {
            velo = velocidade;
        }
        float fowardInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * fowardInput;
        Vector3 moveForward = rb.position + moveDirection * velo * Time.deltaTime;
        rb.MovePosition(moveForward);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        estaPulando = true;
        animator.SetBool("EstaNoChao", false);
    }

    private void TurnAround()
    {
        float sideInput = Input.GetAxis("Horizontal");
        Quaternion deltaRotation = Quaternion.Euler(angleRotation * sideInput * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            estaPulando = false;
            animator.SetBool("EstaNoChao", true);   
        }
        if(collision.gameObject.CompareTag("Placa"))
        {
            estaVivo = false;
            
        }
        if(collision.gameObject.CompareTag("Porta"))
        {
            
            
            SceneManager.LoadScene("Fase2");
            
        }
        if(collision.gameObject.CompareTag("Porta2"))
        {
            
            
            SceneManager.LoadScene("Creditos");
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        podePegar = true;
        

        if(other.gameObject.CompareTag ("Placa"))
        {
            estaVivo = false;
            
        }
        if(other.gameObject.CompareTag("Porta2"))
        {


            SceneManager.LoadScene("Creditos");
            
        }
       
    
        if(other.gameObject.CompareTag("Moeda"))
        {
            pontos++;
            Destroy(other.gameObject);
            
        }
        
    
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
      
        
        
        if(other.gameObject.CompareTag("Porta") && pegando && temChave)
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Abrir");
        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        pegando = false;
        podePegar = false;
    }
public int ContagemPontos()
    { return pontos; }
    

    


   

    

    public bool VerificaSePlayerEstaVivo()
    {
        return estaVivo;
    
    }
    
}
