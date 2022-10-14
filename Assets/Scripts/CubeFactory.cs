using UnityEngine;
using Object = UnityEngine.Object;

public class CubeFactory : IFactory<Cube>
{
    private readonly Cube _cube;

    public CubeFactory()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.SetActive(false);
        cube.AddComponent<Cube>();
        _cube = cube.GetComponent<Cube>();
    }

    public CubeFactory(Cube cube)
    {
        _cube = cube;
    }

    public Cube Create()
    {
        return Object.Instantiate(_cube);
    }
}