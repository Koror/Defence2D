using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float damage;
    public float Damage {
        get { return damage; }}

    private void Start()
    {
        damage *= PlayerPrefs.GetFloat("PlayerDamage");
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * bulletSpeed;

        if (transform.position.x > Utility.WIDTH || transform.position.x < -Utility.WIDTH ||
            transform.position.y > Utility.HEIGHT || transform.position.y < -Utility.HEIGHT)
            Destroy(gameObject);
    }
}
