using UnityEngine;
using UnityEngine.UIElements;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void SetProgress(float progress)
    {
        slider.value = Mathf.Clamp01(progress);
    }
}