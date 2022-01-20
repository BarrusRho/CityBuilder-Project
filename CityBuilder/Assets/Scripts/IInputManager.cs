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
        void AddListenerOnPointerUpEvent(Action listener);
        void AddListenerOnPointerChangeEvent(Action<Vector3> listener);
        void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
        void AddListenerOnPointerSecondUpEvent(Action listener);
        void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
        void RemoveListenerOnPointerSecondUpEvent(Action listener);
        void RemoveListenerOnPointeSecondChangeEvent(Action<Vector3> listener);
        void RemoveListenerOnPointerUpEvent(Action listener);
        void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener);
    }

}
