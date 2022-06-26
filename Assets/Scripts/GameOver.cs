using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameMaster.Instance.gameOver = true;
            GameObject.Find("GameOverText").GetComponent<UnityEngine.UI.Text>().enabled = true;
        }
    }
}
