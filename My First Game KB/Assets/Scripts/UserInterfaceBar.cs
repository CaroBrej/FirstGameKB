using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceBar : MonoBehaviour
{
    public Slider slider;
    public Text barText;


    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        barText.text = slider.value + " / " + slider.maxValue;
    }

    public void SetValue(int value)
    {
        slider.value = value;
        barText.text = slider.value + " / " + slider.maxValue;
    }
}
