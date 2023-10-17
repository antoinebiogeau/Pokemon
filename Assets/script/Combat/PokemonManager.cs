using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    public PokemonData data;
    public int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        // Initialise les valeurs à partir de data
        currentHP = data.maxHP;
        // ... etc.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
