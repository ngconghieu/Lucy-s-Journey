using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private void Awake()
    {
        if (healthSlider == null)
        {
            healthSlider = GetComponentInChildren<Slider>();
            if (healthSlider == null)
            {
                Debug.LogError("HealthSlider is not assigned and no Slider component found on the GameObject.", gameObject);
            }
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    public void SetHealth(int health)
    {
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
    }
}
