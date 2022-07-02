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
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    public void Hit(float impact)
    {
        health -= impact / hitDiv;
        if (health <= 0)
        {
            GameMaster.Instance.money += this.money;
            // Dead
            Destroy(gameObject);
        }
        else
        {
            barObj.transform.localScale = new Vector3(health / 100, 1, 1);
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
