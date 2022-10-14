using System.Collections.Generic;
using UnityEngine;

public class CubePool
{
    private const byte DEFAULT_CUBE_POOL = 5;
    private const string POOL_NAME = "CUBES_POOL";

    private List<Cube> _cubes = new();

    private Transform _poolParent;

    private CubeFactory _cubeFactory;

    public Transform PoolParent => _poolParent;
    
    public CubePool(Transform poolParent, Cube cube)
    {
        CreatePoolWithPrefab(poolParent, cube);
    }

    public CubePool(Transform poolParent)
    {
        CreatePoolWithPrefab(poolParent, null);
    }

    public List<Cube> GetPool()
    {
        return _cubes;
    }

    public Cube GetCube()
    {
        foreach (var cube in _cubes)
        {
            if (!cube.gameObject.activeSelf)
            {
                return cube;
            }
        }

        return CreateCube();
    }

    public void SetActiveCube(Cube cube)
    {
        cube.gameObject.SetActive(true);
        cube.transform.SetParent(null);
    }

    public void ReturnToPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.SetParent(_poolParent);
        cube.transform.position = _poolParent.position;
    }
    
    private void CreatePoolWithPrefab(Transform poolParent, Cube cube)
    {
        _poolParent = new GameObject(POOL_NAME).transform;
        _poolParent.SetParent(poolParent);
        _poolParent.transform.position = poolParent.position;

        _cubeFactory = cube is null ? new CubeFactory() : new CubeFactory(cube);

        for (int i = 0; i < DEFAULT_CUBE_POOL; i++)
        {
            CreateCube();
        }
    }

    private Cube CreateCube()
    {
        var cube = _cubeFactory.Create();
        cube.gameObject.SetActive(false);
        cube.transform.SetParent(_poolParent);
        cube.transform.position = _poolParent.position;
        _cubes.Add(cube);
        return cube;
    }
}