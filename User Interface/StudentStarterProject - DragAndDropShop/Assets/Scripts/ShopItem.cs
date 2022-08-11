using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="ShopItem", menuName = "GUI/ShopItem", order =1)]
public class ShopItem : ScriptableObject
{



    public string itemName;

    public Type type;

    public Sprite icon;
    public Color color = Color.white;
}
