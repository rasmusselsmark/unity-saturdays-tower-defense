using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSel : MonoBehaviour
{
    [SerializeField] int towerIndex;
    GameMaster gameMasterObj;
    GameObject selected;

    // Start is called before the first frame update
    void Start()
    {
        gameMasterObj = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        selected = gameObject.transform.Find("Selected").gameObject;
    }


    // Update is called once per frame
    void Update()
    {        
        if (gameMasterObj.towerSelected == towerIndex)
            selected.SetActive(true);
        else
            selected.SetActive(false);
    }

    private void OnMouseDown()
    {
        gameMasterObj.towerSelected = towerIndex;
    }
}
