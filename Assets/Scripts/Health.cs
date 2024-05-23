using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [Header("Attributes")]
   [SerializeField] private int hitP = 2;

    private bool isKilled = false;
   public void TakeDamage(int dmg){
    hitP -= dmg;
    if (hitP <= 0 && !isKilled){
        EnemySpawner.onEnemyKilled.Invoke();
        isKilled = true;
        Destroy(gameObject); 
    }
   }
}
