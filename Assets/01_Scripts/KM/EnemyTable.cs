using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

[CreateAssetMenu(fileName = "EnemyTable", menuName = "Create EnemyTable")]
public class EnemyTable : ScriptableObject
{
    private static EnemyTable _instance;


    public static EnemyTable Instance
    {
        get
        {
            if (_instance == null)            
                _instance = Resources.Load<EnemyTable>("Enemy/EnemyTable");

            return _instance;
        }
    }



    [Serializable]
    public class Data
    {
        [SerializeField]
        private int code;

        [SerializeField]
        private string enemy_Name;

        [SerializeField]
        private string spriteName;

        [SerializeField]
        private string enemy_AttackType;

        [SerializeField]
        private string enemy_Weapon;

        [SerializeField]
        private int enemy_HP;

        [SerializeField]
        private float enemy_RoamingRange;

        [SerializeField]
        private float enemy_MoveSpeed;

        public int Code => code;
        public string Enemy_Name => enemy_Name;
        public string SpriteName => spriteName;
        public int Enemy_HP => enemy_HP;
        public float Enemy_RoamingRange => enemy_RoamingRange;
        public float Enemy_MoveSpeed => enemy_MoveSpeed;
    }

    public List<Data> datas;

    public Data Find(int code)
    {
        return datas.Find(x => x.Code == code);
    }
  
}
