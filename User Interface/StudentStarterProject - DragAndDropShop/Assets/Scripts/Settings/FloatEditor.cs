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

    public string formatString = "0.0";

    float _floatValue;
    public float floatValue
    {
        get { return _floatValue; }
        set { floatValue = value;
            if (slider)
                slider.value = value;
            if (input)
                input.text = value.ToString(formatString);

            onValueChanged.Invoke(_floatValue);
        }
    }

    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    public FloatEvent onValueChanged;

    void Start()
    {
        if (slider)
            slider.onValueChanged.AddListener((float value) => { floatValue = value; });
        if (input)
            input.onEndEdit.AddListener((string text) =>
            {
                float parsedValue;
                if (float.TryParse(text, out parsedValue))
                    floatValue = parsedValue;
            });
    }
}
