using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder
{
    public class Cell
    {
        private GameObject _structureModel = null;
        private bool _isTaken = false;

        public bool IsTaken { get => _isTaken; }

        public void SetConstruction(GameObject structureModel)
        {
            if (structureModel == null)
            {
                return;
            }
            this._structureModel = structureModel;
            this._isTaken = true;
        }
    }

}
