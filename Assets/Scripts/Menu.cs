using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
  [Header("References")]
  [SerializeField] TextMeshProUGUI moneyUI;
  [SerializeField] TextMeshProUGUI HPLeft;
  [SerializeField] Animator anim;

  private bool isMenuOpen = true;

  public void ToggleMenu(){
    isMenuOpen  = !isMenuOpen;
    anim.SetBool("MenuOpen", isMenuOpen);
  }

  private void OnGUI(){
      moneyUI.text = LevelManager.main.money.ToString();
      HPLeft.text = (GameController.main.losingEnemyPasses - GameController.main.enemyPasses).ToString();
  }

}
