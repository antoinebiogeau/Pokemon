using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    public PokemonData data;
    public int currentHP;
    void Start()
    {
        currentHP = data.maxHP;
    }
    void Update()
    {
        
    }
}
