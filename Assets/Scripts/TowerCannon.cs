using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCannon : MonoBehaviour
{
    [SerializeField] float hitImpact = 10;
    [SerializeField] float fireRate = 10;   // pr. s
    [SerializeField] GameObject bulletObj;
    public int cost;

    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nextFire += Time.deltaTime;
    }

    Vector3 DirCalc(Vector3 src, Vector3 dst, float speed)
    {
        Vector3 v;
        v = new Vector3(dst.x - src.x, dst.y - src.y, 0).normalized * speed;
        return v;
    }

    float AngleCalc(Vector3 v1, Vector3 v2)
    {
        float angle;

        angle = Vector3.Angle(v1, v2);
        if (v2.x > v1.x)
            angle = 360 - angle;
        return angle;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject localBulletObj;
            BulletCtrl bulletCtrl;
            Vector3 dir;
            if (nextFire > 1 / fireRate)
            {
                localBulletObj = Instantiate(bulletObj, transform.position, bulletObj.transform.rotation);
                bulletCtrl = localBulletObj.GetComponent<BulletCtrl>();
                dir = DirCalc(transform.position, collision.transform.position, 80);
                bulletCtrl.direction = dir;
                bulletCtrl.hitImpact = hitImpact;
                nextFire = 0;

                float angle;
                angle = AngleCalc(Vector3.up, dir);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}
