using UnityEngine;

public class BoxFactory : IFactory<Box>
{
    private Box _box;
    public void SetPrefab(Box box)
    {
        _box = box;
    }
    public Box Create()
    {
        return Object.Instantiate(_box);
    }
}