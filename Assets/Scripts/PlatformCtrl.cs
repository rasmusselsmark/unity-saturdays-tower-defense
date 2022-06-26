using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCtrl : MonoBehaviour
{
    [SerializeField] GameObject[] towersObj;
    GameObject currentTowerObj = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (currentTowerObj == null)
        {
            currentTowerObj = Instantiate(towersObj[GameMaster.Instance.towerSelected], transform.position, transform.rotation);
        }
    }
}
