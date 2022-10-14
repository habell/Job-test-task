using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

    private float _speed, _distance, _spawnTime;

    private void Awake()
    {
        _cubePool = new CubePool(transform);
        _cubeMove = new CubeMove(_cubePool);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            _speed = float.TryParse(_cubeSpeedInput.text, out _speed) ? _speed : 10f;
            _distance = float.TryParse(_cubeDistanceInput.text, out _distance) ? _distance : 10f;
            _spawnTime = float.TryParse(_cubeSpawnTimeInput.text, out _spawnTime) ? _spawnTime : 10f;

            _cubeMove.SetParameters(_speed, _distance);
        }
    }

    private void FixedUpdate()
    {
        _cubeMove.MoveCube();
    }
}