using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class HP_Changer : MonoBehaviour
{
    [SerializeField] private Button _upHPButton;
    [SerializeField] private Button _downHPButton;
    [SerializeField] private Player _player;
    [SerializeField] private Slider _hpBar;
    //[SerializeField] private HP_Changer _changer;
    [SerializeField] private float recoveryRate;

    private float _damage = 10f;
    private float _heal = 10f;
    private float _nextHPBarValue;
    private Coroutine _SetHealthPointCoroutine;

    public event UnityAction HealthChanged;

    private void Start()
    {
        _upHPButton.onClick.AddListener(OnClickUpHpButton);
        _downHPButton.onClick.AddListener(OnClickDownHpButton);
        _hpBar.maxValue = _player.MaxHealth;
    }

    private void OnEnable()
    {
        HealthChanged += RunCoroutine;
    }

    private void OnDisable()
    {
        HealthChanged -= RunCoroutine;
    }

    private void RunCoroutine()
    {
        _nextHPBarValue = _player.Health;
        _SetHealthPointCoroutine = StartCoroutine(SetHealthPointBar());
    }

    private IEnumerator SetHealthPointBar()
    {
        while (_hpBar.value != _nextHPBarValue)
        {
            _hpBar.value = Mathf.MoveTowards(_hpBar.value, _nextHPBarValue, recoveryRate * Time.deltaTime);

            yield return null;
        }

        if (_hpBar.value == _nextHPBarValue)
        {
            StopCoroutine(_SetHealthPointCoroutine);
        }
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
