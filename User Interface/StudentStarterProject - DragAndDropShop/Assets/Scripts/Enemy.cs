using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Fighter
{
    public Color[] sprites;
    int lastIndex;
    int index;
    public Image enemy;
    public Type type;

    public override void Hit(int damage)
    {
        base.Hit(damage);
        ChangeIndex();
    }

    public override void Die()
    {
        GameManager.instance.timer.lastHit = GameManager.instance.timer.cooldown;
        health = maxHealth;
        UpdateUI();
    }

    void ChangeIndex()
    {
        index = Random.Range(0,4);
        if (index == sprites.Length)
            index = 0;

        enemy.color = sprites[index];
        type = (Type)index;

        lastIndex = index;
    }

    public bool Check(ShopItem compare)
    {
        return (compare.type == type);
    }
}
