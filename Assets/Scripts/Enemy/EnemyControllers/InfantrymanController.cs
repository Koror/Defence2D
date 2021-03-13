using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantrymanController : EnemyController
{
    private bool playerCollision=false;
    private void Update()
    {
        if(!playerCollision)
            Move();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        BulletCollision(collision);
        if (collision.gameObject.tag == "Player")
        {
            playerCollision = true;
            StartCoroutine(Attack(collision.gameObject));
        }
    }

    private IEnumerator Attack(GameObject player)
    {
        while (true)
        {
            if (player != null)
            {
                player.GetComponent<PlayerController>().GetDamage(Damage);
                yield return new WaitForSeconds(1.2f);
            }
            else
                break;
        }
    }
}
