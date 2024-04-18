using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour

{
    public Text healthText;
    public Image healthbar;
    public Player playerHealth; // Reference to the player's health script

    void Update()
    {
        healthText.text = playerHealth.currentHealth.ToString("0") + "%";
        healthbar.fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
