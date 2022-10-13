using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    
    private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ChangeHealth(float health)
    {
        _health += health;

        if (_health <= 0)
            _health = 0;

        if (_health >= _maxHealth)
            _health = _maxHealth;
    }
}
