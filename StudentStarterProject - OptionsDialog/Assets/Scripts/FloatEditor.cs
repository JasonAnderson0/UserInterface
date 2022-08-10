using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class FloatEditor : MonoBehaviour
{
    [Header("Components")]
    public Slider slider;
    public TMP_InputField input;
    // string used to format the text field when you move the slider
    // see https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings for details
    public string formatString = "0.0";

 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
