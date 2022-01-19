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
        private bool _isBuildingModeActive = false;

        private void Start()
        {
            CameraMovement.SetCameraLimits(0, Width, 0, Length);
            InputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
            _grid = new GridStructure(_cellSize, Width, Length);
            InputManager.AddListenerOnPointerDownEvent(HandleInput);
            InputManager.AddListenerOnPointerSecondDownEvent(HandleInputCameraPan);
            InputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
            UIController.AddListenerOnBuildAreaEvent(StartPlacementMode);
            UIController.AddListenerOnCancelActionEvent(CancelAction);
        }

        private void HandleInputCameraPanStop()
        {
            CameraMovement.StopCameraMovement();
        }

        private void HandleInputCameraPan(Vector3 position)
        {
            if (_isBuildingModeActive == false)
            {
                CameraMovement.MoveCamera(position);
            }
        }

        private void HandleInput(Vector3 position)
        {
            Vector3 gridPosition = _grid.CalculateGridPosition(position);
            if (_isBuildingModeActive == true && _grid.IsCellTaken(gridPosition) == false)
            {
                PlacementManager.CreateBuilding(gridPosition, _grid);
            }
        }

        private void StartPlacementMode()
        {
            _isBuildingModeActive = true;
        }

        private void CancelAction()
        {
            _isBuildingModeActive = false;
        }
    }
}
