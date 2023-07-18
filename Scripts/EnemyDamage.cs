using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    private float damage;

    void Start()
    {
        damage = 100;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            player.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
