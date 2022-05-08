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
            PlayerPrefs.SetInt("Coins", 1000);
            PlayerPrefs.SetFloat("Speed", 50);
            PlayerPrefs.SetInt("SpeedCost", 20);
            PlayerPrefs.SetInt("Health",8);
            PlayerPrefs.SetInt("FirstLoad",1);
        }
        
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
