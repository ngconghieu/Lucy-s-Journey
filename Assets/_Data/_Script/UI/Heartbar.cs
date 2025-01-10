using UnityEngine;
using UnityEngine.UI;

public class Heartbar : MonoBehaviour
{
   
    [SerializeField] private Slider slider;

    private void Awake()
    {
        if (slider == null)
        {
            slider = GetComponentInChildren<Slider>();
            if (slider == null)
            {
                Debug.LogError("slider is not assigned and no Slider component found on the GameObject.", gameObject);
            }
        }
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
