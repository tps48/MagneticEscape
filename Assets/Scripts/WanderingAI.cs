using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive;

    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive == true)
        {


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        

    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
