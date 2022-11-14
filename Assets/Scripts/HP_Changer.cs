using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP_Changer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Buttons _buttons;
    [SerializeField] private float recoveryRate;

    private float _nextHPBarValue;
    private Coroutine _SetHealthPointCoroutine;


    private void Start()
    {
        _hpBar.maxValue = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _buttons.HealthChanged += RunCoroutine;
    }

    private void OnDisable()
    {
        _buttons.HealthChanged -= RunCoroutine;
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
}
