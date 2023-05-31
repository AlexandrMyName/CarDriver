using Profile;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEditor;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath() { PathResource = "Prefabs/Input" };
        private readonly BaseInputView _view;

        public InputController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            Profile.Car carModel)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, carModel.Speed);
        }
        

        private BaseInputView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            BaseInputView view = objectView.GetComponent<BaseInputView>();
            return view;
        }
    }
}
