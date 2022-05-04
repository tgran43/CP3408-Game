using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerHealth;
    private TextMeshProUGUI moneyText;
    public int coinBalance;

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        UpdateHealth();
        moneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealth()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player has died...");
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            HealthDamage();
        }
        if (collision.tag == "Coin")
        {
            coinBalance = coinBalance + 1;
            moneyText.text = "" + coinBalance;
        }
    }

    public void HealthDamage()
    {
        playerHealth -= 1;
        UpdateHealth();
    }

    public void GainHealth()
    {
        playerHealth += 1;
        UpdateHealth();
    }
}