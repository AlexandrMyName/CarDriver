using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal abstract class BaseController : IDisposable
{
    private List<BaseController> _controllers = new List<BaseController>();
    private List<GameObject> _objects = new List<GameObject>();
    private bool _disposed; 
    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;

            if (_controllers != null)
            {
                foreach (BaseController baseController in _controllers)
                {
                    baseController?.Dispose();
                }
                _controllers.Clear();
            }
            if (_objects != null)
            {
                foreach (GameObject cachedGameObject in _objects)
                {
                    GameObject.Destroy(cachedGameObject);
                }
                _objects.Clear();
            }
            OnDispose();
        }
    }
    protected void AddController(BaseController baseController)
    {
        if (_controllers == null)
            _controllers = new List<BaseController>();
        _controllers.Add(baseController);
    }
    protected void AddGameObjects(GameObject gameObject)
    {
        if (_objects == null)
            _objects = new List<GameObject>();
        _objects.Add(gameObject);
    }

    protected virtual void OnDispose()
    {

    }
}
