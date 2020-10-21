using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class SliderImageData : MonoBehaviour
{
    private Slider healthSlider;
    public FloatData health, maxHealth;
    private RectTransform rectTransform;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = maxHealth.value;
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        healthSlider.value = health.value;
       // rectTransform.sizeDelta.x = maxValue.value
    }
}
