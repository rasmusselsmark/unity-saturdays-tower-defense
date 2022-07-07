using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject barObj;
    [SerializeField] float hitDiv = 10;
    public ParticleSystem SmokeParticleSystem;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hit(float impact)
    {
        //Debug.Log("Hit " + health);
        health -= impact / hitDiv;
        if (health < 50 && SmokeParticleSystem != null)
        {
            SmokeParticleSystem.gameObject.SetActive(true);
        }
        
        if (health <= 0)
        {
            // Killed
            Destroy(gameObject);
        }
        else
            barObj.transform.localScale = new Vector3(health / 100, 1, 1);
    }
}
