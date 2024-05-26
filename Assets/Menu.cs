using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
  [Header("References")]
  [SerializeField] TextMeshProUGUI moneyUI;

  private void OnGUI(){
      moneyUI.text = LevelManager.main.money.ToString();

  }

}
