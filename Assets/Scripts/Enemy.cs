using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 自動的にターゲットオブジェクトに向かって移動するようにする。
        navMeshAgent.destination = target.transform.position;

        // アニメーション設定
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }
}
