using UnityEngine;
using UnityEngine.Networking;

public abstract class HPController : NetworkBehaviour
{
    private Animator _animator;
    [SyncVar] private int _hp;

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
