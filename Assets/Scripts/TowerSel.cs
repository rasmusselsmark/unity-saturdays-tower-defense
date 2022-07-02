using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSel : MonoBehaviour
{
    [SerializeField] int towerIndex;
    [SerializeField] int cost; // TODO: duplicate field!
    GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        selected = gameObject.transform.Find("Selected").gameObject;
    }


    // Update is called once per frame
    void Update()
    {        
        if (GameMaster.Instance.towerSelected == towerIndex && GameMaster.Instance.money >= cost)
        {
            selected.SetActive(true);
        }
        else
        {
            selected.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        GameMaster.Instance.towerSelected = towerIndex;
    }
}
