using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCtrl : MonoBehaviour
{
    [SerializeField] GameObject[] towersObj;
    GameObject currentTowerObj = null;
    GameMaster gameMasterObj;

    // Start is called before the first frame update
    void Start()
    {
        gameMasterObj = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (currentTowerObj == null)
        {
            Debug.Log(gameMasterObj.towerSelected);
            currentTowerObj = Instantiate(towersObj[gameMasterObj.towerSelected], transform.position, transform.rotation);
        }
    }
}
