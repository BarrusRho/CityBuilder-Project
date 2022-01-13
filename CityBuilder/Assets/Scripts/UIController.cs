using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace CityBuilder
{
    public class UIController : MonoBehaviour
    {
        private Action OnBuildAreaHandler;
        private Action OnCancelActionHandler;

        public Button BuildResidentialAreaButton;
        public Button CancelActionButton;
        public GameObject CancelActionPanel;

        private void Start()
        {
            CancelActionPanel.SetActive(false);
            BuildResidentialAreaButton.onClick.AddListener(OnBuildAreaCallback);
            CancelActionButton.onClick.AddListener(OnCancelActionCallback);
        }

        private void OnBuildAreaCallback()
        {
            CancelActionPanel.SetActive(true);
            OnBuildAreaHandler?.Invoke();
        }
        
        private void OnCancelActionCallback()
        {
            CancelActionPanel.SetActive(false);
            OnCancelActionHandler?.Invoke();
        }

        public void AddListenerOnBuildAreaEvent(Action listener)
        {
            OnBuildAreaHandler += listener;
        }

        public void RemoveListenerOnBuildAreaEvent(Action listener)
        {
            OnBuildAreaHandler -= listener;
        }

        public void AddListenerOnCancelActionEvent(Action listener)
        {
            OnCancelActionHandler += listener;
        }

        public void RemoveOnCancelActionEvent(Action listener)
        {
            OnCancelActionHandler -= listener;
        }
    }
}
