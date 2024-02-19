using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// scriptable object example for an player
/// use this class to create a wide variety of enemies with basic attributes
/// to use the class, create a new scriptable object in the assets folder, and set the variables in the inspector
/// to call the class, use the following code:
///     PlayerScriptableObject player = new EnemyScriptableObject();
///     player.enemyName = "player";
///     player.health = 100;
///     player.damage = 10;
///     player.speed = 5;
///     etc...
///     Debug.Log(player.playerName);
///     Debug.Log(player.health);
///     etc...
/// </summary>

public class PlayerScriptableObject : MonoBehaviour
{
    public string playerName;
    public int health;
    public int damage;
    public float speed;
    public float attackRange;
    public float chaseRange;
    public float attackCooldown;
    public float attackDuration;
    public float attackDelay;
}
