using UnityEngine;

public class CubeMove
{
    private GameObject _cubeObject;
    private CubePool _cubePool;
    private Transform _startPosition;
    private float _speed;
    private float _maxDistance;

    public CubeMove(CubePool cubePool, float speed, float maxDistance)
    {
        SetParameters(speed, maxDistance);
        _cubePool = cubePool;
        _startPosition = _cubePool.PoolParent.transform;
    }

    public void SetParameters(float speed, float maxDistance)
    {
        _speed = speed;
        _maxDistance = maxDistance;
    }

    public void MoveCube()
    {
        foreach (var cube in _cubePool.GetPool())
        {
            _cubeObject = cube.gameObject;
            if (_cubeObject.activeSelf)
            {
                _cubeObject.transform.Translate(Vector3.right * _speed);
                var dist = Vector3.Distance(_startPosition.position, _cubeObject.transform.position);
                if (dist >= _maxDistance) _cubePool.ReturnToPool(cube);
            }
        }
    }
}