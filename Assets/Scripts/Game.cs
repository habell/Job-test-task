using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _cubeSpeedInput;

    [SerializeField]
    private TMP_InputField _cubeDistanceInput;

    [SerializeField]
    private TMP_InputField _cubeSpawnTimeInput;

    private CubePool _cubePool;

    private CubeMove _cubeMove;

    private float _speed, _distance, _spawnTime, _spawnTimerCount;

    private void Awake()
    {
        ParseParameters();
        _cubePool = new CubePool(transform);
        _cubeMove = new CubeMove(_cubePool, _speed, _distance);
        SpawnCube();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            ParseParameters();
            _cubeMove.SetParameters(_speed, _distance);
        }
    }

    private void FixedUpdate()
    {
        _spawnTimerCount -= Time.fixedDeltaTime;
        if (_spawnTimerCount <= 0) SpawnCube();
        _cubeMove.MoveCube();
    }

    private void SpawnCube()
    {
        _spawnTimerCount = _spawnTime;
        var cube = _cubePool.GetCube();
        _cubePool.SetActiveCube(cube);
    }

    private void ParseParameters()
    {
        _speed = (float.TryParse(_cubeSpeedInput.text, out _speed) ? _speed : 10f) / 1000;
        _distance = float.TryParse(_cubeDistanceInput.text, out _distance) ? _distance : 10f;
        _spawnTime = float.TryParse(_cubeSpawnTimeInput.text, out _spawnTime) ? _spawnTime : 10f;
        _spawnTimerCount = _spawnTime - _spawnTimerCount;
    }
}