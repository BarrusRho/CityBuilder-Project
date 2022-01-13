using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder
{
    public class GridStructure
    {
        private int _cellSize;
        private Cell[,] _grid;
        private int _width, _length;

        public GridStructure(int cellSize, int width, int length)
        {
            this._cellSize = cellSize;
            this._width = width;
            this._length = length;
            _grid = new Cell[this._width, this._length];

            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                for (int column = 0; column < _grid.GetLength(1); column++)
                {
                    _grid[row, column] = new Cell();
                }
            }
        }

        public Vector3 CalculateGridPosition(Vector3 inputPosition)
        {
            int x = Mathf.FloorToInt((float)inputPosition.x / _cellSize);
            int z = Mathf.FloorToInt((float)inputPosition.z / _cellSize);
            return new Vector3(x * _cellSize, 0, z * _cellSize);            
        }

        private Vector2Int CalculateGridIndex (Vector3 gridPosition)
        {
            return new Vector2Int((int)(gridPosition.x / _cellSize), (int)(gridPosition.z / _cellSize));
        }

        public bool IsCellTaken (Vector3 gridPosition)
        {
            var cellIndex = CalculateGridIndex(gridPosition);
            if(CheckIndexValidity(cellIndex))
            {
                return _grid[cellIndex.y, cellIndex.x].IsTaken;
            }
            else
            {
                throw new IndexOutOfRangeException($"No index {cellIndex} in grid");
            }
        }

        public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition)
        {
            var cellIndex = CalculateGridIndex(gridPosition);
            if(CheckIndexValidity(cellIndex))
            {
                _grid[cellIndex.y, cellIndex.x].SetConstruction(structure);
            }
        }

        private bool CheckIndexValidity(Vector2Int cellIndex)
        {
            if(cellIndex.x >= 0 && cellIndex.x < _grid.GetLength(1) && cellIndex.y >= 0 && cellIndex.y < _grid.GetLength(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
