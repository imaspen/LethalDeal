using UnityEngine;

public abstract class HPController : MonoBehaviour
{
    public int MaxHP;

    public int HP { get; private set; }

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
