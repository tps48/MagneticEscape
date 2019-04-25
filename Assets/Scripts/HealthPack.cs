using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HealthPack : MonoBehaviour
{


    void OnCollisionEnter(Collision collision)
    {
        PlayerCharacter player = collision.gameObject.GetComponent<PlayerCharacter>();
        if (player != null && player.GetHealth() < 5)
        {
            player.AddHealth();
        }
        else
        {
            Physics.IgnoreCollision(GameObject.FindWithTag("PlayerCharacter").GetComponent<Collider>(), GetComponent<Collider>(), true);
        }
        Destroy(this.gameObject);
    }
}
