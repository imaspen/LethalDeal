using UnityEngine;
using UnityEngine.Networking;

public abstract class HPController : NetworkBehaviour
{
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
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0) Die();
    }

    protected abstract void Die();
}
