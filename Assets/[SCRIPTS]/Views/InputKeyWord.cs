using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.InputLogic{ 
    internal class InputKeyWord : BaseInputView
    {
        [SerializeField] private float _multiplier = 0.05f;



        private void Start() => UpdateManager.SubscribeToUpdate(Move);
        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);



        private void Move()
        {
            float mainValue = CalcValue();
            float moveValue = speed * _multiplier * Time.deltaTime * mainValue;

            

            if (mainValue < 0) OnLeftMove(moveValue);
            else if(moveValue > 0 )OnLeftMove(moveValue);
        }

        private float CalcValue()
        {
             

            float horizontalInput = Input.GetAxis("Horizontal");

            
            return horizontalInput;
        }
    }
}
