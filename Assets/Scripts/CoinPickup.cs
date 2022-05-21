using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    private TextMeshProUGUI moneyText;
    public int coinBalance;
    public AudioSource moneyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        moneyAudioSource = GameObject.Find("coinSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moneyAudioSource.Play();
            Destroy(this.gameObject);
            
        }
    }
}
