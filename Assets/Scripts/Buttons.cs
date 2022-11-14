using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _upHPButton;
    [SerializeField] private Button _downHPButton;
    [SerializeField] private PlayerHealth _player;

    private float _damage = 10f;
    private float _heal = 10f;

    public event UnityAction HealthChanged;

    private void Start()
    {
        _upHPButton.onClick.AddListener(OnClickUpHpButton);
        _downHPButton.onClick.AddListener(OnClickDownHpButton);
    }

    private void OnClickUpHpButton()
    {
        _player.TakeHeal(_heal);
        HealthChanged?.Invoke();
    }

    private void OnClickDownHpButton()
    {
        _player.TakeDamage(_damage);
        HealthChanged?.Invoke();
    }
}
