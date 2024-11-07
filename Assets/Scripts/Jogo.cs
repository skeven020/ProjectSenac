using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Jogo : MonoBehaviour
{
    [SerializeField] private Player player;
    //Tela de morte
    [SerializeField] private GameObject TelaDaMorte;
    private GameObject [] Moeda;
    [SerializeField] public TextMeshProUGUI pontos;
    [SerializeField] private TextMeshProUGUI pontosRestantes;
    [SerializeField] private TextMeshProUGUI avisoMissao;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        TelaDaMorte.SetActive(false);
        pontos = GameObject.Find("Pontos").GetComponent<TextMeshProUGUI>();
        Moeda = GameObject.FindGameObjectsWithTag("Moeda");
        pontosRestantes = GameObject.FindWithTag("PontosRestantes").GetComponent<TextMeshProUGUI>();
        pontosRestantes.text = Moeda.Length.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (!player.VerificaSePlayerEstaVivo())
        {
           TelaDaMorte.SetActive(true);
        }
        pontos.text = player.ContagemPontos().ToString();
        int contagem = player.ContagemPontos();

        if(player.ContagemPontos() >= Moeda.Length)
        {
            
            avisoMissao.text = "Encoste na Porta";
            
        }
        else
        {
            avisoMissao.text = "Colete as moedas";
        }
    

        
    }
    public bool PodePassarFase()
    {
        if(player.ContagemPontos() >= Moeda.Length)
        {
            return true;
            
        }

        return false;
    }
    public void Play()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void End()
    {
        SceneManager.LoadScene("Fim");
    }
 
    

}
