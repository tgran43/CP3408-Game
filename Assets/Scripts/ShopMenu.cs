using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public float speed;
    public int speedCost;
    public TextMeshProUGUI speedCostText;
    public TextMeshProUGUI coinBalanceText;
    private void Start()
    {
        speed = PlayerPrefs.GetFloat("Speed");
        speedCost = PlayerPrefs.GetInt("SpeedCost");
        

        if (speedCost != 1)
        {
            speedCostText.text = "" + speedCost;
        }
        else
        {
            speedCostText.text = "MAX";
        }
        coinBalanceText.text = "" + PlayerPrefs.GetInt("Coins");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("MenuScene");
    }

    public void SpeedUpgrade()
    {
        if (PlayerPrefs.GetInt("Coins") >= speedCost)
        {
            if (PlayerPrefs.GetInt("SpeedCost") != 1)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - speedCost);
                coinBalanceText.text = "" + PlayerPrefs.GetInt("Coins");
            }

            speed = PlayerPrefs.GetFloat("Speed");
            speedCost = PlayerPrefs.GetInt("SpeedCost");
            if (speed == 50f)
            {
                speed = 75f;
                speedCost += 20;
            }
            else if (speed == 75f)
            {
                speed = 100f;
                speedCost += 20;
            }
            else if (speed == 100f)
            {
                speed = 125f;
                speedCost = 1;
            }

            PlayerPrefs.SetFloat("Speed", speed);
            PlayerPrefs.SetInt("SpeedCost", speedCost);
            if (speedCost != 1)
            {
                speedCostText.text = "" + speedCost;
            }
            else
            {
                speedCostText.text = "MAX";
            }
            Debug.Log(PlayerPrefs.GetInt("SpeedCost"));
        }

        PlayerPrefs.SetFloat("Speed", speed);
    }

    public void HealthUpgrade()
    {

    }

    public void BoostConsumable()
    {

    }

}
