using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BoxPool
    {
        private const byte DEFAULT_BOX_POOL = 5;
        private const string POOL_NAME = "BOXES_POOL";
        
        private List<Box> _boxes = new();
        
        private Transform _poolParent;
        
        private BoxFactory _boxFactory;

        public Transform PoolParent => _poolParent;

        public BoxPool(Transform poolParent, Box box)
        {
            _poolParent = new GameObject(POOL_NAME).transform;
            _poolParent.SetParent(poolParent);
            _poolParent.transform.position = poolParent.position;

            _boxFactory = new BoxFactory();
            _boxFactory.SetPrefab(box);

            for (int i = 0; i < DEFAULT_BOX_POOL; i++)
            {
                CreateBox();
            }
        }

        public List<Box> GetPool()
        {
            return _boxes;
        }

        public Box GetBox()
        {
            foreach (var box in _boxes)
            {
                if (!box.gameObject.activeSelf)
                {
                    return box;
                }
            }

            return CreateBox();
        }

        public void SetActivebox(Box box)
        {
            box.gameObject.SetActive(true);
            box.transform.SetParent(null);
        }

        public void ReturnToPool(Box box)
        {
            box.gameObject.SetActive(false);
            box.transform.SetParent(_poolParent);
            box.transform.position = _poolParent.position;
        }

        private Box CreateBox()
        {
            var box = _boxFactory.Create();
            box.gameObject.SetActive(false);
            box.transform.SetParent(_poolParent);
            box.transform.position = _poolParent.position;
            _boxes.Add(box);
            return box;
        }
    }
}