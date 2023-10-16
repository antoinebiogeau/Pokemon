using UnityEngine;
using UnityEngine.UI;


public class CombatManager : MonoBehaviour
{
    public Pokemon playerPokemon;
    public Pokemon enemyPokemon;

    public void PlayerAttack(int attackIndex)
    {
        Attack chosenAttack = playerPokemon.attacks[attackIndex];
        float damage = chosenAttack.damage; // Vous pouvez ajouter des modificateurs en fonction des types ici
        enemyPokemon.TakeDamage(damage);

        // Log pour l'attaque du joueur
        Debug.Log("Le joueur a utilisé " + chosenAttack.attackName + " et a infligé " + damage + " dégâts à l'ennemi.");
        Debug.Log("Fin de tour");
        EnemyTurn();
    
    }

    public void EnemyTurn()
    {
        int randomAttack = Random.Range(0, 4);
        Attack chosenAttack = enemyPokemon.attacks[randomAttack];
        float damage = chosenAttack.damage; // Vous pouvez ajouter des modificateurs en fonction des types ici
        playerPokemon.TakeDamage(damage);

        // Log pour l'attaque de l'ennemi
        Debug.Log("L'ennemi a utilisé " + chosenAttack.attackName + " et a infligé " + damage + " dégâts au joueur.");
        Debug.Log("Fin du tour de l'ennemi.");
    }
}
