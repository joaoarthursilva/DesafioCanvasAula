using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("UI Variables")] [SerializeField]
    private Text damageReceivedText;

    [SerializeField] private Slider healthSlider;

    [Header("Health Variables")] [SerializeField]
    private int startingHealth = 100;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = startingHealth;
    }

    private void Update()
    {
        healthSlider.value = _currentHealth / startingHealth;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != 7) return;
        var damage = col.gameObject.GetComponent<TiroPlayer>().GetDamage();
        TakeDamage(damage);
        UpdateText(damage);
        Invoke(nameof(ClearText), .15f);
    }

    private void UpdateText(int damage)
    {
        damageReceivedText.text = $"{damage}";
    }

    private void ClearText()
    {
        damageReceivedText.text = "";
    }

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
}