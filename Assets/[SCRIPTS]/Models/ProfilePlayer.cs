using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Profile
{
    internal enum GameState { Start, Game, Settings }
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly Car CurrentCar;


        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
        }
        public ProfilePlayer(float speedCar, GameState state) : this(speedCar) =>  CurrentState.Value = state;

        
    }
}

