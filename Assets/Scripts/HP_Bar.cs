using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Player _player;
    [SerializeField] private HP_Changer _changer;
    [SerializeField] private float recoveryRate;

    private float _hpBarValue;
    private float _nextHPBarValue;
    private Coroutine _SetHealthPointCoroutine;

    private void OnEnable()
    {
        _changer.HealthChangedEvent += RunCoroutine;
    }

    private void OnDisable()
    {
        _changer.HealthChangedEvent -= RunCoroutine;
    }

    private void Start()
    {
        _hpBar.maxValue = _player.MaxHealth;       
        _hpBarValue = _player.MaxHealth;
        _nextHPBarValue = _hpBarValue;
    }

    private void RunCoroutine()
    {
        _nextHPBarValue = _player.Health;
        _SetHealthPointCoroutine = StartCoroutine(SetHealthPointBar());
    }

    private IEnumerator SetHealthPointBar()
    {
        if (_hpBarValue > _nextHPBarValue)
        {
            _hpBar.value = Mathf.MoveTowards(_nextHPBarValue, _hpBarValue, recoveryRate * Time.deltaTime);
        }
        else
        {
            _hpBar.value = Mathf.MoveTowards(_hpBarValue, _nextHPBarValue, recoveryRate * Time.deltaTime);
        }

        yield return null;
    }
}
