using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesObj;
    int enemySel;
    float timerS;
    float delayS;
    float nextS;

    // Start is called before the first frame update
    void Start()
    {
        delayS = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.Instance.gameOver)
        {
            return;
        }

        timerS += Time.deltaTime;
        nextS += Time.deltaTime;

        if (nextS > delayS)
        {
            if (timerS > 10)
            {
                enemySel = Random.Range(0, enemiesObj.Length);
            }
            else if (timerS > 1)
            {
                enemySel = 0;
            }

            Instantiate(enemiesObj[enemySel], transform.position, transform.rotation);
            delayS = Random.Range(0.5f, 3.0f);
            nextS = 0;
        }
    }
}
