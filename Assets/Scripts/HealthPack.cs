using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HealthPack : MonoBehaviour
{
    public PlayerCharacter player;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (((collision.gameObject.GetComponent("PlayerCharacter") as PlayerCharacter) != null))
        {
            if (player != null && player.GetHealth() < 5)
            {
                player.AddHealth();
            }
            else
            {
                Physics.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<Collider>(), GetComponent<Collider>(), true);
            }
        }
        Destroy(this.gameObject);
    }
}
