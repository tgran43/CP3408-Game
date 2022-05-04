using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    private TextMeshProUGUI moneyText;
    public int coinBalance;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
