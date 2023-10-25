using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PokemonType", menuName = "Pokemon/Type", order = 2)]
public class PokemonTypeData : ScriptableObject
{
    public string typeName;
    public List<PokemonType> strongAgainst; 
    public List<PokemonType> weakAgainst; 
}
