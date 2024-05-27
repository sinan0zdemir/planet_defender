using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform[] path;
    public Transform startPoint;

    public int money;
    private void Awake(){
        main = this;
    }
    
    private void Start(){
        money = 100;
    }

    public void IncreaseMoney(int amount){
        money += amount;
    }
    
    public void SpendMoney(int amount){
        money -= amount;
    }

    public bool CanBuy(int amount){
        if(amount  <= money){
            return true;        
        }else{
            return false;
        }
    }
}
