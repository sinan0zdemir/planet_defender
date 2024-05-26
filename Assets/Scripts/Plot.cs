using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Start(){
        startColor = sr.color;
    }

    private void OnMouseEnter(){
        sr.color = hoverColor;
    }

    private void OnMouseExit(){
        sr.color = startColor;
    }

    private void OnMouseDown(){
        if(tower != null )return;

        Tower tempTower = BuildManager.main.GetSelectedTower();
        if(tempTower.cost > LevelManager.main.money) {
            Debug.Log("You can't buy this tower");
            return;
        }
        LevelManager.main.CanBuy(tempTower.cost);

        
        tower = Instantiate(tempTower.prefab, transform.position, Quaternion.identity);
    }

}
