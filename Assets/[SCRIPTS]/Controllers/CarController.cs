using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.Car
{
    internal class CarController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };
        private readonly CarView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public CarController()
        {
            _view = LoadView();
        }
        private CarView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return objectView.GetComponent<CarView>();
        }
    }
}
