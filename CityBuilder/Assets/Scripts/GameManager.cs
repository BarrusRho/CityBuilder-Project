using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder
{
    public class GameManager : MonoBehaviour
    {
        public InputManager InputManager;
        public PlacementManager PlacementManager;
        public int Width, Length;
        private GridStructure _grid;
        private int _cellSize = 3;

        private void Start()
        {
            _grid = new GridStructure(_cellSize, Width, Length);
            InputManager.AddListenerOnPointerDownEvent(HandleInput);
        }

        private void HandleInput(Vector3 position)
        {
            Vector3 gridPosition = _grid.CalculateGridPosition(position);
            if (_grid.IsCellTaken(gridPosition) == false)
            {
                PlacementManager.CreateBuilding(gridPosition, _grid);
            }
        }
    }
}
