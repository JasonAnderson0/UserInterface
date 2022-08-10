using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    Player player;
    public Action action;
    [Header("Child Components")]
    public Image icon;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    public void Start()
    {
        SetAction(action);
    }
    public void Init(Player p)
    {
        player = p;
        Button button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(() => { player.DoAction(action); });
        }
    }

    public void SetAction(Action a)
    {
        action = a;
        if (action)
        {
            if (nameTag)
                nameTag.text = action.actionName;
            if (descriptionTag)
                descriptionTag.text = action.description;
            if (icon)
            {
                icon.sprite = action.icon;
                icon.color = action.color;
            }
        }
    }
}
