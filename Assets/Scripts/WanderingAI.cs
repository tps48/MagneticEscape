﻿using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private EnemyReactiveTarget _enemyReactiveTarget;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive;

    void Start()
    {
        _alive = true;
        _enemyReactiveTarget = GetComponent<EnemyReactiveTarget>();
    }

    void Update() 
    {
        if (_alive)
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null && _enemyReactiveTarget._alive == true)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
            }
        }
    }


        public void SetAlive(bool alive)
        {
            _alive = alive;
        }
    }
