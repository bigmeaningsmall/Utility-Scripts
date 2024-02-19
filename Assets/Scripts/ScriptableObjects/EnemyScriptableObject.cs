using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// scriptable object example for an enemy
/// use this class to create a wide variety of enemies with basic attributes
/// to use the class, create a new scriptable object in the assets folder, and set the variables in the inspector
/// to call the class, use the following code:
///     EnemyScriptableObject enemy = new EnemyScriptableObject();
///     enemy.enemyName = "enemy";
///     enemy.health = 100;
///     enemy.damage = 10;
///     enemy.speed = 5;
///     etc...
///     Debug.Log(enemy.enemyName);
///     Debug.Log(enemy.health);
///     etc...
/// </summary>

public class EnemyScriptableObject : MonoBehaviour
{
    public string enemyName;
    public int health;
    public int damage;
    public float speed;
    public float attackRange;
    public float chaseRange;
    public float attackCooldown;
    public float attackDuration;
    public float attackDelay;
}
