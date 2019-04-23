using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyReactiveTarget : MonoBehaviour
{
    public bool _alive;
    private Animator _animator;
    public Deflection _deflect;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isAlive", true);
        _alive = true;
        _deflect = GetComponent<Deflection>();
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "");
        if ((collision.gameObject.GetComponent("ReactiveTarget") as ReactiveTarget) != null)
            if (_deflect._deflectAmt < 5)
            {
                _deflect._deflectAmt++;
            }
            else
            {
                GameObject.FindGameObjectWithTag("EnemyDeath").GetComponent<MusicClass1>().PlayMusic();

                _animator.SetBool("isAlive", false);
                _alive = false;
                StartCoroutine(Die());

            }
        }

    private IEnumerator Die()
    {

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);



    }
}

