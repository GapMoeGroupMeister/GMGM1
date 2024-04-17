using UnityEngine;

namespace EntityManage
{
    [System.Serializable]
    public struct Status
    {
        public bool isResist;
        public int hp;
        [SerializeField] private int maxHP;
        public int MaxHp => maxHP;

        public bool canMove;
        public float moveSpeed;
        public float detectDistance;

    }
}