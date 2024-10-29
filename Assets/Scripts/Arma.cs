using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "Arma", menuName = "Novo Item/ Arma")]

public class Arma : Item
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public GameObject itemPrefab;
    public bool ehMagica;
    public int dano;
    public int danoAdicional;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string Nome()
    {
        return nome;
    }

    public override string Descricao()   
    {
        return descricao;
    }

    public override Sprite Sprite()
    {
        return sprite;
    }

    public override GameObject ItemPrefab()
    {
        return itemPrefab;
    }

    public bool EhMagico()
    {
        return ehMagica;
    }

    public int Dano()
    {
        return dano;
    }

    public int DanoAdicional()
    {
         return danoAdicional;
    }
}

