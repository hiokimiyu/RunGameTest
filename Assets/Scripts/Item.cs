using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject _item;

    /// <summary>
    /// -1,0,1
    /// </summary>
    int _pos;
    void Start()
    {
        _pos = 1;

        for (int i = -10; i * 5 < 50; i++)
        {
            int item = 0;

            if (_pos == 0)
            {
                item = Random.Range(-1, 2);
            }
            else if (_pos == 1)
            {
                item = Random.Range(0, 2);
            }
            else if (_pos == -1)
            {
                item = Random.Range(-1, 1);
            }
            _pos = item;
            Instantiate(_item, new Vector3(item * 5, 1.5f, i * 5), Quaternion.identity, gameObject.transform);
        }
    }
}
