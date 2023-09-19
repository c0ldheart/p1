using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: 执行顺序不一定，全部用框架Entity
        _playerTransform = FindObjectOfType<PlayerControler>().transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        var position = _playerTransform.position;
        transform.position = new Vector3(position.x, position.y,
            -10);
    }
}