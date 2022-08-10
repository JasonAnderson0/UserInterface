using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Fighter
{
    public Color[] sprites;
    int index;
    public Image enemy;

    public override void Die()
    {
        index++;
        if (index == sprites.Length)
            index = 0;

        enemy.color = sprites[index];
        health = maxHealth;
        UpdateUI();
    }
}
