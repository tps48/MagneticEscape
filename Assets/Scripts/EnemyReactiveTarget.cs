using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReactiveTarget : MonoBehaviour
{

    private void OnCollisionEnter(Collider collision)
    {
        Debug.Log("collision name = " + collision.gameObject.name);
        if (collision.gameObject.name == "enemy" )
        {
            Destroy(collision.gameObject);
        }
    }
}
