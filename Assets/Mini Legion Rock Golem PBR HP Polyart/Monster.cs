using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Renderer m_Renderer;
    [SerializeField] private Animator m_Animator;

    private IEnumerator IE_MonsterHitHandle = null;
    private IEnumerator IE_MonsterSpawnHandle = null;

    void Start()
    {
        
    }

    public void MonsterSpawn()
    {
        StartCoroutine(IE_MonsterSpawnHandle = IE_MonsterAppear());
    }

    public void MonsterHit()
    {
        StartCoroutine(IE_MonsterHitHandle = IE_MonsterHit());
    }

    public void MonsterHit(float _DissolveTime)
    {
        StartCoroutine(IE_MonsterHitHandle = IE_MonsterHit(_DissolveTime));
    }

    private IEnumerator IE_MonsterHit(float _DissolveTime = 1.0f)
    {
        m_Animator.SetBool("IsDie", true);
        yield return new WaitUntil(() => m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Die") && m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95F);
        yield return IE_MonsterDissolve(false, _DissolveTime, ()=> Destroy(gameObject));
    }

    private IEnumerator IE_MonsterAppear(float _DissolveTime = 1.0f)
    {
        m_Animator.SetBool("IsDie", false);
        yield return IE_MonsterDissolve(true, _DissolveTime);
    }

    private IEnumerator IE_MonsterDissolve(bool _IsAppear, float _DissolveTime, Action _AfterAct = null)
    {
        float t_CurrTime = 0.0f;
        while (_DissolveTime > t_CurrTime)
        {
            t_CurrTime += Time.deltaTime;
            m_Renderer.material.SetFloat("_Alpha", _IsAppear ? 1 - (t_CurrTime / _DissolveTime) : t_CurrTime / _DissolveTime);
            yield return null;
        }
        _AfterAct?.Invoke();
    }
   
}
