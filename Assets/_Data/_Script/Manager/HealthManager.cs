using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;


    public void SetMaxHealth(int health)
    {
        if (slider == null)
        {
            Debug.LogError("Slider is not assigned in HealthManager.");
            return;
        }
        slider.maxValue = health;
        slider.value = health;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void TakeDamage(int damage)
    {
        slider.value -= damage;
    }
}
