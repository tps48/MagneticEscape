using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    [SerializeField] private GameObject ClonePrefab;
    private GameObject _enemy;

    void Update()
    {
        int i = 0;
        if (Random.Range(0, 5000) == 1)
        {
            for (i = 0; i < 2; i++)
            {
                _enemy = Instantiate(ClonePrefab) as GameObject;
                _enemy.transform.position = new Vector3(this.transform.position.x + Random.Range(-10.0f, 10.0f), 0, this.transform.position.z + Random.Range(-10.0f, 10.0f));
            }
            i = 0;

        }
       
           
      
    }
}
