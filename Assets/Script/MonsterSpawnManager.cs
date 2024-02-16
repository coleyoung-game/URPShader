using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private Monster m_Monster;
    [SerializeField] private Vector3[] m_MonsterSpawnPos;

    private int m_SelectIdx = -1;
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.anyKey)
        {
            if (int.TryParse(Input.inputString, out m_SelectIdx))
                SpawnMonster(m_SelectIdx);
        }
    }

    private void SpawnMonster(int _Idx)
    {
        if (_Idx < 0 || _Idx > m_MonsterSpawnPos.Length - 1)
            return;
        GameObject t_Monster = Instantiate(m_Monster.gameObject);
        t_Monster.transform.position = m_MonsterSpawnPos[_Idx];
        t_Monster.GetComponent<Monster>().MonsterSpawn();
    }
}
