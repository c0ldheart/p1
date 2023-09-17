using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Transform sprite;

    public float speed;

    public float minSize, maxSize;

    private float _activeSize;
    // Start is called before the first frame update
    void Start()
    {
        _activeSize = maxSize;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.localScale = Vector3.MoveTowards(sprite.localScale, Vector3.one * _activeSize, speed * Time.deltaTime);
        if (sprite.localScale.x == _activeSize)
        {
            _activeSize = _activeSize == maxSize ? minSize : maxSize;
        }
    }
}
