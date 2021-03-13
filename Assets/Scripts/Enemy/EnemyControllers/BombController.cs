using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : EnemyController
{
    private void Update()
    {
        Move();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        BulletCollision(collision);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}
