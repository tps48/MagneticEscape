﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflection : MonoBehaviour
{
    public bool _alive;
    private Animator _animator;
    private int _hitAmt;
    public int _deflectAmt;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isAlive", true);
        _alive = true;
        _hitAmt = 0;
        _deflectAmt = 0; 
    }


    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent("ReactiveTarget") as ReactiveTarget) != null)
        {
            if (_hitAmt < 5)
            {
                _hitAmt++;
                Physics.IgnoreCollision(GameObject.FindWithTag("ReactiveTarget").GetComponent<Collider>(), GetComponent<Collider>(), true);
            }

            else
            {
                GameObject.FindGameObjectWithTag("EnemyDeath").GetComponent<MusicClass1>().PlayMusic();

                _animator.SetBool("isAlive", false);
                _alive = false;
                StartCoroutine(Die());
            }
        }
    }


    private IEnumerator Die()
    {

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}




