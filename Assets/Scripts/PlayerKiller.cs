using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && GameController.Singleton.GameState == GameState.PLAYING)
        {
            GameController.Singleton.GameState = GameState.DEFEAT;
        }
    }
}
