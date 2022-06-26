using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // Public variables, will be overwritten when created
    // Default values are for debug only
    public Vector3 direction = 10*Vector3.left; // Incl speed
    public float hitImpact = 200;

    float lifeTimeS = 2;

    // Start is called before the first frame update
    void Start()
    {
        //direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.x * Time.deltaTime, direction.y * Time.deltaTime, 0);
        lifeTimeS -= Time.deltaTime;
        if (lifeTimeS < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyObj = collision.gameObject.GetComponent<Enemy>();
            enemyObj.Hit(hitImpact);
            Destroy(gameObject);
        }
    }
}
