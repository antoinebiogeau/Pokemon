using UnityEngine;

[CreateAssetMenu(fileName = "NewAttack", menuName = "Pokemon/AttackData", order = 1)]
public class AttackData : ScriptableObject
{
    public string attackName;
    public PokemonTypeData attackType;
    public float damage;
}
