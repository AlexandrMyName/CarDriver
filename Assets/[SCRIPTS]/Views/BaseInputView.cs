using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Windows;

namespace Game.InputLogic
{ 

internal class BaseInputView : MonoBehaviour
{
    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;
    protected float speed;


    public virtual void Init(
        SubscriptionProperty<float> leftMove,
        SubscriptionProperty<float> rightMove,
        float speedCar
        )
    {
        _leftMove = leftMove;
        _rightMove = rightMove;
        speed = speedCar;
         
    }


    protected void OnLeftMove(float value) => _leftMove.Value = value;
    protected void OnRightMove(float value) => _rightMove.Value = value;

}
}