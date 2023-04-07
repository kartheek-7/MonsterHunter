using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    //public Gradient gradient;
   //public Image image;
    public void SetHealth(int health)
    {
        slider.value = health;
        //image.color=gradient.Evaluate(slider.value);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        //image.color=gradient.Evaluate(slider.value);
    }
}
