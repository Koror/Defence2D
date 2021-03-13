using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : EnemyController
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private Transform fullHPBar;

    private float targetDistance;
    private float currentDistance;

    private void Start()
    {
        StartCoroutine(Action());
    }

    private IEnumerator Action()
    {
        Vector3 currentPosition= transform.position;
        Quaternion currentRotation = transform.rotation;
        //rotation to player
        Vector2 direction = Vector3.zero - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //position Health Bar
        fullHPBar.position = currentPosition;
        fullHPBar.position += new Vector3(0,0.4f,0);
        fullHPBar.rotation = currentRotation;

        float startDistance = (Vector3.zero - transform.position).magnitude;
        targetDistance = startDistance / 2;
        currentDistance = (Vector3.zero - transform.position).magnitude;
        while (currentDistance > targetDistance)
        {
            Move();
            currentDistance = (Vector3.zero - transform.position).magnitude;
            yield return null;
        }
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(bullet, bulletPos.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        BulletCollision(collision);
    }
}
