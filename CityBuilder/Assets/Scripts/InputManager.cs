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
        void GetInput();
        void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
    }

    public class InputManager : MonoBehaviour, IInputManager
    {
        private Action<Vector3> OnPointerDownHandler;
        public LayerMask MouseInputMask;

        private void Update()
        {
            GetInput();
        }

        public void GetInput()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, MouseInputMask))
                {
                    Vector3 position = hit.point - transform.position;
                    OnPointerDownHandler?.Invoke(position);
                }
            }
        }

        public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
        {
            OnPointerDownHandler += listener;
        }

        public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
        {
            OnPointerDownHandler -= listener;
        }
    }

}
