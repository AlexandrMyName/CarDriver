using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.InputLogic
{
    internal class InputGyroView : BaseInputView
    {
        [SerializeField] private float _multiplier = 0.05f;



        private void Start() => UpdateManager.SubscribeToUpdate(Move);
        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);



        private void Move()
        {
            if(!SystemInfo.supportsGyroscope) return;

            Quaternion quaternion = Input.gyro.attitude;
            quaternion.Normalize();

            float offset = quaternion.x + quaternion.y;
            float moveValue = speed * _multiplier * Time.deltaTime * offset;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0) OnRightMove(abs);
            else OnLeftMove(abs);
        }

       
    }
}
