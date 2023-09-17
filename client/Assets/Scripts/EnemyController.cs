using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<PlayerControler>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = (_target.position - transform.position) * moveSpeed;
    }
}
