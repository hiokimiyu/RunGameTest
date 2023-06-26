using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody = default;
    [SerializeField] float _speed = default;
    [SerializeField] GameObject _gol = default;
    [SerializeField] bool _isLane = false;
    [SerializeField] float[] _lane = default;
    /// <summary>
    /// 2,1,0
    /// </summary>
    [SerializeField] int _index = 1;
    [SerializeField] float _interval = 0.5f;

    bool _isStop = false;
    Vector3 _dir = default;
    float _moveX = 0;
    float _timer = 0;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _isStop = false;
        _index = 1;
        _timer = _interval;
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _moveX = Input.GetAxis("Horizontal");

            if (!_isStop && !_isLane)
                MoveX();

            if (_isLane && !_isStop)
                MoveLane();

            if (_moveX > 0 | _moveX < 0)
            {
                _timer = 0;
            }
        }

        if (_gol.transform.position.z < gameObject.transform.position.z)
        {
            _isStop = true;
        }

        if (_isStop)
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }

    private void MoveLane()
    {
        _dir = new Vector3(0, 0, _speed);
        _rigidBody.velocity = _dir;

        if (_moveX < 0) { _index--; }
        if (_moveX > 0) { _index++; }

        if (_index < 0) { _index = 0; }
        if (_index > _lane.Length - 1) { _index = 2; }

        Vector3 pos = new Vector3(_lane[_index], transform.position.y, transform.position.z);
        transform.position = pos;
    }

    private void MoveX()
    {
        _dir = new Vector3(_moveX * _speed, 0, _speed);
        _rigidBody.velocity = _dir;
    }

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    // performed、canceledコールバックを受け取る
    //    if (context.started) return;

    //    Debug.Log(context);
    //    // Moveアクションの入力取得
    //    var inputMove = context.ReadValue<Vector2>();

    //    // 移動処理など
    //    Vector2 vector2 = context.ReadValue<Vector2>();
    //    _moveX = vector2.x;
    //}
}