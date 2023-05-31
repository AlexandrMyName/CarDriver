using System;

namespace Tools
{
    internal interface IReadOnlySubscriptionProperty<out T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscriptionOnChange(Action<T> unsubscriptionAction);
    }
}

