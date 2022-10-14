using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CubeMove
{
    private GameObject _cubeObject;
    private List<Cube> _cubePool;
    private Transform _startPosition;
    private float _speed;
    private float _distance;

    public CubeMove(CubePool cubePool)
    {
        InstantiateMove(cubePool, 10f, 100f);
    }

    public CubeMove(CubePool cubePool, float speed, float distance)
    {
        InstantiateMove(cubePool, speed, distance);
    }

    public void SetParameters(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
    }

    public void MoveCube()
    {
        foreach (var cube in _cubePool)
        {
            _cubeObject = cube.gameObject;
            if (_cubeObject.activeSelf)
            {
                _cubeObject.transform.Translate(Vector3.right / (1000f - _speed));
                
            }
        }
    }

    private void InstantiateMove(CubePool cubePool, float speed, float distance)
    {
        SetParameters(speed, distance);
        _cubePool = cubePool.GetPool();
        _startPosition = cubePool.PoolParent.transform;
    }
}