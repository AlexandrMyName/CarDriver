using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Game.BackGround
{
    internal class BackGroundController : BaseController
    {
        private readonly SubscriptionProperty<float> _diff;
        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;
        private ResourcePath _path = new ResourcePath() { PathResource = "Prefabs/BackGround" };
        private  BackGroundView _view;

        public BackGroundController(
            SubscriptionProperty<float> leftMove,
             SubscriptionProperty<float> rightMove
            )
        {
            
            _leftMove = leftMove;
            _rightMove = rightMove;
            _view = LoadView();
            _diff = new SubscriptionProperty<float>();
            _view.Init(_diff);
            _leftMove.SubscribeOnChange(MoveLeft);
            _rightMove.SubscribeOnChange(MoveRight);
        }
        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(MoveLeft);
            _rightMove.UnSubscriptionOnChange(MoveRight);
        }

        private BackGroundView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(_path);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            BackGroundView view = objectView.GetComponent<BackGroundView>();
            return view;
        }

        private void MoveRight(float value) => _diff.Value = value;

        private void MoveLeft(float value) => _diff.Value = value;
        
    }
}
