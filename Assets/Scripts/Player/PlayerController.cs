using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private Transform HPBar;
    [SerializeField]
    private float health;
    public float Health { get { return health; } }
    private float maxHealth;
    [SerializeField]
    private float fireDelay;
    private float fireCurrentTime;

    void Start()
    {
        fireCurrentTime = fireDelay;
        health *= PlayerPrefs.GetFloat("PlayerHealth");
        maxHealth = health;
    }

    void Update()
    {
        //rotation to cursor
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //shooting
        fireCurrentTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if(fireCurrentTime > fireDelay)
            {
                Instantiate(bullet, bulletPos.position, transform.rotation);
                fireCurrentTime = 0;
            }
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        HPBar.localScale = new Vector3(Health / maxHealth, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage(collision.gameObject.GetComponent<EnemyBulletController>().Damage);
            Destroy(collision.gameObject);
        }
    }
}
