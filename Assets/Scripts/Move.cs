using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] float _speed;
    [SerializeField] GameObject _gol;
    bool _isStop = false;
    Vector3 _dir = default;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStop)
        {
            _rigidBody.velocity = Vector3.zero;
        }

        if (_gol.transform.position.z > gameObject.transform.position.z)
        {
            _dir = new Vector3(0, 0, _speed);
            _rigidBody.velocity = _dir;
            _isStop = true;
        }
    }
}