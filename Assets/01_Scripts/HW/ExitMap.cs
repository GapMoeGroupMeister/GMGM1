using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Transform mapTrm = MapManager.Instance.NextStage();
            if (GameManager.Instance.IsGameClear)
                GameManager.Instance.GameClear();

        }
    }
}