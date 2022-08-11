using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider timer;
    public int cooldown;
    [HideInInspector]
    public float lastHit;
    public Fighter enemy;
    public Fighter player;

    void Start()
    {
        timer = GetComponent<Slider>();
        timer.maxValue = cooldown;
    }

    void Update()
    {
        timer.value = Time.time - lastHit;
        if (timer.value >= cooldown)
        {
            lastHit = Time.time;
            player.Hit(enemy.damage);
            timer.value = timer.maxValue;
        }
    }
}
