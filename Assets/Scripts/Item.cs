using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual string Nome()
    {
        return nome;
    }

    public virtual string Descricao()   
    {
        return descricao;
    }

    public virtual Sprite Sprite()
    {
        return sprite;
    }

    public virtual GameObject ItemPrefab()
    {
        return itemPrefab;
    }
}

