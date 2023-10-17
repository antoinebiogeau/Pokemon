using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemon", menuName = "Pokemon/Data", order = 0)]
public class PokemonData : ScriptableObject
{
    public string pokemonName;
    public Mesh pokemonMesh;
    public int maxHP;
    public int attack;
    public int defense;
    public int specialAttack;
    public int specialDefense;
    public int speed;
    public PokemonType pokemonType;
    public Attack[] attacks = new Attack[4];

    
}
