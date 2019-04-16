using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflection : MonoBehaviour
{
    public bool _alive;
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isAlive", true);
        _alive = true;
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "");
        if ((collision.gameObject.GetComponent("ReactiveTarget") as ReactiveTarget) != null)
        {
            if (Random.Range(1, 5) == 1)
            {
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




