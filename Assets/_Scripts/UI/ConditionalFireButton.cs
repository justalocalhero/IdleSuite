using UnityEngine;
using UnityEngine.UI;

public class ConditionalFireButton : MonoBehaviour
{
    private Button button;
    public IntValue buildValue;
    public ConditionalFire conditionalFire;

    void Awake()
    {
        button = GetComponentInChildren<Button>();
    }

    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        conditionalFire.TryFire(buildValue.Value);
    }
}