using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReactiveTarget : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "");
        if (collision.gameObject.name == "Sphere" )
        {
            Destroy(this.gameObject);
        }
    }
}
