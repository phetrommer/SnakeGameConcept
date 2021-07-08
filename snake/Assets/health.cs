using UnityEngine;

public class health : MonoBehaviour
{
    public int hp;

    private void Awake()
    {
        hp = 100;
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (hp <= 0) Destroy(gameObject);
    }
}