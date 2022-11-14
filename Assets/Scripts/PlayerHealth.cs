using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    
    private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float health)
    {
        _health -= health;

        if (_health <= 0)
            _health = 0;
    }

    public void TakeHeal(float health)
    {
        _health += health;

        if (_health >= _maxHealth)
            _health = _maxHealth;
    }
}
