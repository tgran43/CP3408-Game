using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;



public class Health : MonoBehaviour
{
    public int playerHealth;
    private TextMeshProUGUI moneyText;
    public int coinBalance;
    public GameObject deathMenuUI;
    public int health;

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        coinBalance = PlayerPrefs.GetInt("Coins");
        UpdateHealth();
        moneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        moneyText.text = "" + coinBalance;
        playerHealth = PlayerPrefs.GetInt("Health");
    }

    public void UpdateHealth()
    {
        health = PlayerPrefs.GetInt("Health");
        if (playerHealth <= 0)
        {
            PauseMenu.DeathMenu(deathMenuUI);
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
            SaveGame();
        }
    }

    public void HealthDamage()
    {
        playerHealth -= 1;
        UpdateHealth();
    }

    public int CoinBalance()
    {
        return coinBalance;
    }

    public void GainHealth()
    {
        playerHealth += 1;
        UpdateHealth();
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Coins", coinBalance);

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SaveGame();
        }
    }
}
