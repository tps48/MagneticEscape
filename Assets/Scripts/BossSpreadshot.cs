using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpreadshot : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public Vector3 rightoffset = new Vector3(0, 0, 1.2f);
    public Vector3 leftoffset = new Vector3(0, 0, 0.8f);

    private BossEnemyReactiveTarget _enemyReactiveTarget;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball1;
    private GameObject _fireball2;
    private GameObject _fireball3;

    private bool _alive;

    void Start()
    {
        _alive = true;
        _enemyReactiveTarget = GetComponent<BossEnemyReactiveTarget>();
    }

    void Update()
    {
        if (_alive)
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball1 == null && _enemyReactiveTarget._alive == true)
                    {
                        _fireball1 = Instantiate(fireballPrefab) as GameObject;
                        _fireball2 = Instantiate(fireballPrefab) as GameObject;
                        _fireball3 = Instantiate(fireballPrefab) as GameObject;
                        _fireball1.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball2.transform.position = transform.TransformPoint(rightoffset * 1.5f);
                        _fireball3.transform.position = transform.TransformPoint(leftoffset * 1.5f);
                        _fireball1.transform.rotation = transform.rotation;
                        _fireball2.transform.rotation = transform.rotation;
                        _fireball3.transform.rotation = transform.rotation;
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
