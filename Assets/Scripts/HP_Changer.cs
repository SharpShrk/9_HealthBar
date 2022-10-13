using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HP_Changer : MonoBehaviour
{
    [SerializeField] private Button _upHPButton;
    [SerializeField] private Button _downHPButton;
    [SerializeField] private Player _player;

    private float _deltaHealth;

    public event UnityAction HealthChangedEvent;

    private void Start()
    {
        _upHPButton.onClick.AddListener(OnClickUpHpButton);
        _downHPButton.onClick.AddListener(OnClickDownHpButton);
    }

    private void OnClickUpHpButton()
    {
        _deltaHealth = 10f;
        ChangeHealth(_deltaHealth);
    }

    private void OnClickDownHpButton()
    {
        _deltaHealth = -10f;
        ChangeHealth(_deltaHealth);
    }

    private void ChangeHealth(float health)
    {
        _player.ChangeHealth(health);
        HealthChangedEvent?.Invoke();
    }
}
