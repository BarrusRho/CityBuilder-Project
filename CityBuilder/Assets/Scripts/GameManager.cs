using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace CityBuilder
{
    public class GameManager : MonoBehaviour
    {
        public IInputManager InputManager;
        public PlacementManager PlacementManager;
        public UIController UIController;
        public int Width, Length;
        public CameraMovement CameraMovement;
        private GridStructure _grid;
        private int _cellSize = 3;
        
        private PlayerState _state;

        public PlayerSelectionState SelectionState;
        public PlayerBuildingSingleStructureState BuildingSingleStructureState;

        private void Awake()
        {
            _grid = new GridStructure(_cellSize, Width, Length);
            SelectionState = new PlayerSelectionState(this, CameraMovement);
            BuildingSingleStructureState = new PlayerBuildingSingleStructureState(this, PlacementManager, _grid);
            _state = SelectionState;
        }

        private void Start()
        {
            CameraMovement.SetCameraLimits(0, Width, 0, Length);

            InputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();

            InputManager.AddListenerOnPointerDownEvent(HandleInput);
            InputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPan);
            InputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
            InputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);

            UIController.AddListenerOnBuildAreaEvent(StartPlacementMode);
            UIController.AddListenerOnCancelActionEvent(CancelAction);
        }

        private void HandlePointerChange(Vector3 position)
        {
            _state.OnInputPointerChange(position);
        }

        private void HandleInputCameraPanStop()
        {
            _state.OnInputPanUp();
        }

        private void HandleInputCameraPan(Vector3 position)
        {
            _state.OnInputPanChange(position);
        }

        private void HandleInput(Vector3 position)
        {
            _state.OnInputPointerDown(position);
        }

        private void StartPlacementMode()
        {
            TransitionToState(BuildingSingleStructureState);
        }

        private void CancelAction()
        {
            _state.OnCancel();
        }

        public void TransitionToState(PlayerState newState)
        {
            this._state = newState;
            this._state.EnterState();
        }
    }
}
