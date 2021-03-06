using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float hitDiv = 10;
    [SerializeField] GameObject barObj;
    [SerializeField] int money = 10;
    int path;
    
    [SerializeField]
    float health;


    // Start is called before the first frame update
    void Start()
    {
        path = 0;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(transform.right * speed * Time.deltaTime);
    }

    public void Hit(float impact)
    {
        health -= impact / hitDiv;
        if (health <= 0)
        {
            GameMaster.Instance.money += this.money;
            // Dead
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            barObj.GetComponent<HealthBar>().SetHealth(health);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Waypoint")
        {
            var waypoint = col.gameObject.GetComponent<Waypoint>();
            transform.rotation = Quaternion.Euler(0, 0, waypoint.Direction);
        }
    }
}
