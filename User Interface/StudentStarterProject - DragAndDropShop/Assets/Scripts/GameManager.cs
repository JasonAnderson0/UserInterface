using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Fire,
    Water,
    Earth,
    Air
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Fighter player;
    public Enemy enemy;
    public Timer timer;

    void Awake()
    {
        instance = this;
    }

}
