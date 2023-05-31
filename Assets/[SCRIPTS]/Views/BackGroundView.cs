using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.BackGround
{
    internal class BackGroundView : MonoBehaviour
    {
        [SerializeField] private BackGroundTiles[] _backgrounds;

        private IReadOnlySubscriptionProperty<float> _diff;

        public void Init(IReadOnlySubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }
        private void OnDestroy()
        {
            _diff?.UnSubscriptionOnChange(Move);
        }

        private void Move(float value)
        {
            foreach(var backGround in _backgrounds)
            {
                backGround.Move(-value);
            }
        }
    }
}
