using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageMine : MonoBehaviour
{
    [SerializeField] private int mineDamage;

    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }
    void Damage()
    {
        _health.playerHealth = _health.playerHealth - mineDamage;
        _health.UpdateHealth();
        gameObject.SetActive(false);
    }
}
