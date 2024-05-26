using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [Header("Attributes")]
   [SerializeField] private int hitP = 2;
   [SerializeField] private int moneyWorth = 10 ;

   private bool isKilled = false;
   public void TakeDamage(int dmg){
    hitP -= dmg;
    if (hitP <= 0 && !isKilled){
        EnemySpawner.onEnemyKilled.Invoke();
        LevelManager.main.IncreaseMoney(moneyWorth);
        isKilled = true;
        Destroy(gameObject); 
    }
   }
}
