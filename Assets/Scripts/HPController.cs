using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour {
    public int MaxHP;

    private int _currentHP;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) takeDamage(5);
    }

    public void Start()
    {
        _currentHP = MaxHP;
    }

    public void takeDamage(int amount)
    {
        _currentHP -= amount;
        if (_currentHP > 0) return;
        Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
