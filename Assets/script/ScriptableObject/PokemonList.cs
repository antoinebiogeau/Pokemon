using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PokemonList", menuName = "Pokemon/List", order = 1)]
public class PokemonList : ScriptableObject
{
    public List<PokemonData> allPokemons;
}
