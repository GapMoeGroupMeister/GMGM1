using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealpackItem : Item
{
    [SerializeField]
    private int _healAmount = 25;
    public override void GetItem(PlayerController player)
    {
        base.GetItem(player);

        player.RestoreHealth(_healAmount);
    }
}
