using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    NONE,
    STRAIGHT,
    LEFT,
    RIGHT,

    VICTORY
}

public class BoosterEffecter : MonoBehaviour
{
    [SerializeField] private EffectType effectType;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && GameController.Singleton.GameState == GameState.PLAYING)
        {
            Handle(collider.GetComponent<Player>());
        }
    }

    private void Handle(Player player)
    {
        var game = GameController.Singleton;

        switch(effectType)
        {
            case EffectType.STRAIGHT:
                game.BoostStraight();
            break;
            case EffectType.LEFT:
                game.BoostLeft();
            break;
            case EffectType.RIGHT:
                game.BoostRight();
            break;
            case EffectType.VICTORY:
                 GameController.Singleton.GameState = GameState.VICTORY;
            break;
            default:
                GameController.Singleton.GameState = GameState.DEFEAT;
            return;
        }

        GetComponent<Collider2D>().enabled = false;
        GetComponentInParent<BoosterController>()?.Pass();
        game.NextBooster();
    } 
}
