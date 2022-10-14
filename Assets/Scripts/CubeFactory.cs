using System;
using Object = UnityEngine.Object;

public class CubeFactory : IFactory<Cube>
{
    private readonly Cube _cube;
    public CubeFactory(Cube cube)
    {
        _cube = cube;
    }
    public Cube Create()
    {
        return Object.Instantiate(_cube);
    }
    
    
}