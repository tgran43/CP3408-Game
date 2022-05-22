using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.GetInt("FirstLoad") == 0)
        {
            PlayerPrefs.SetInt("Coins", 0);
            PlayerPrefs.SetFloat("Speed", 50);
            PlayerPrefs.SetInt("SpeedCost", 20);
            PlayerPrefs.SetInt("Health",5);
            PlayerPrefs.SetInt("FirstLoad",1);
        }
        PlayerPrefs.SetInt("Health", 5);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
