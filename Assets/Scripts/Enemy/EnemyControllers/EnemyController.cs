using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public float Speed;
    public float Health;
    public float Damage;

    private float maxHealth;
    [SerializeField]
    private Transform HPBar;
    [SerializeField]
    protected float score;

    public void Initialize()
    {
        Speed *= PlayerPrefs.GetFloat("EnemySpeed");
        Health *= PlayerPrefs.GetFloat("EnemyHealth");
        Damage *= PlayerPrefs.GetFloat("EnemyDamage");
        maxHealth = Health;
    }
    protected void Move()
    {
        Vector3 distance = (Vector3.zero - transform.position).normalized;
        //normalized direction
        Vector3 direction = Vector3.zero;
        if (distance.magnitude != 0)
            direction = distance / distance.magnitude;
        transform.position += direction * Speed * Time.deltaTime;
    }

    protected void BulletCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= collision.gameObject.GetComponent<BulletController>().Damage;
            UpdateHealthBar();
            Destroy(collision.gameObject);
            if (Health <= 0)
            {
                ScoreManager.instance.AddScore(score);
                Destroy(gameObject);
            }
        }
    }

    private void UpdateHealthBar()
    {
        HPBar.localScale = new Vector3(Health / maxHealth,1 ,1 ); 
    }
    abstract protected void OnCollisionEnter2D(Collision2D collision);
}
