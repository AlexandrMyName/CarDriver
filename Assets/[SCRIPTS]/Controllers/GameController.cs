using Game.BackGround;
using Game.Car;
using Game.InputLogic;
using JoostenProductions;
using Profile;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game
{
    internal class GameController : BaseController
    {
        

        public GameController (ProfilePlayer _playerProfile)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

             BackGroundController backGroundController = new BackGroundController(leftMoveDiff,rightMoveDiff);
             AddController(backGroundController);
           
            InputController inputController = new InputController(leftMoveDiff,rightMoveDiff,_playerProfile.CurrentCar);
            AddController(inputController);

            CarController carController = new CarController();
            AddController(carController);

             
        }
    }
}
