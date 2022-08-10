using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ShopItem[] items;
    public int Money;

    // Start is called before the first frame update
    void Start()
    {
        Money = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
