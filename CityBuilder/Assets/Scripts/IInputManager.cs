using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CityBuilder
{
    public interface IInputManager
    {
        void AddListenerOnPointerDownEvent(Action<Vector3> listener);
        void AddListenerOnPointerSecondDownEvent(Action<Vector3> listener);
        void AddListenerOnPointerSecondUpEvent(Action listener);
        void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
        void RemoveListenerOnPointerSecondUpEvent(Action listener);
        void RemoveListenerOnPointeSecondDownEvent(Action<Vector3> listener);
    }

}
