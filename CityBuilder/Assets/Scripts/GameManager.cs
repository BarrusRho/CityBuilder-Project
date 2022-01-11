using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder
{
    public class GameManager : MonoBehaviour
    {
        public InputManager InputManager;
        public PlacementManager PlacementManager;
        private GridStructure _grid;
        private int _cellSize = 3;

        private void Start()
        {
            _grid = new GridStructure(_cellSize);
            InputManager.AddListenerOnPointerDownEvent(HandleInput);
        }

        private void HandleInput(Vector3 position)
        {
            PlacementManager.CreateBuilding(_grid.CalculateGridPosition(position));
        }
    }
}
