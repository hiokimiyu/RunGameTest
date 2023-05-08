using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] float _speed;
    bool isStop = false;
    Vector3 _dir = default;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir = new Vector3(0, 0, _speed);
        _rigidBody.velocity = _dir;
    }
}