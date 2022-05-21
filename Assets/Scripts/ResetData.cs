using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class ResetData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MenuScene");
    }    
}
