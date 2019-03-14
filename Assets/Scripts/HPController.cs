using UnityEngine;
using UnityEngine.Networking;

public abstract class HPController : NetworkBehaviour
{
    [SyncVar] private int _hp;
    private Animator _animator;
    
    public int MaxHP;

    public int HP
    {
        get { return _hp; }
        private set { _hp = value; }
    }

    public void Start()
    {
        HP = MaxHP;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0) Die();
        else _animator.SetTrigger("Damage");
    }

    protected abstract void Die();
}
