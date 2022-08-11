using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    Slider slider;
    public int health;
    public int maxHealth;
    public int damage;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        health = maxHealth;
    }

    public virtual void Hit(int damage) 
    {
        health -= damage;
        UpdateUI();
        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Application.Quit();
        Debug.Log("You died");
    }

    public void UpdateUI() 
    {
        slider.value = health;
    }
}
