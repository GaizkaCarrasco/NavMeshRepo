using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private bool isHitting;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        isHitting = true;
        animator.SetTrigger("Attack 01");
        yield return new WaitForSeconds(0.5f);
        isHitting = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject ghost = collision.gameObject;
        if(ghost.GetComponent<GhostMovement>() != null && isHitting == false)
        {
            StartCoroutine(DieCoroutine());
        }
    }

    IEnumerator DieCoroutine()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);
    }
}
