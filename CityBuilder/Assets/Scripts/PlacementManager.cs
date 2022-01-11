using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder
{
    public class PlacementManager : MonoBehaviour
    {
        public GameObject BuildingPrefab;
        public Transform Ground;

        private void Start()
        {

        }

        public void CreateBuilding(Vector3 gridPosition)
        {
            Instantiate(BuildingPrefab, Ground.position + gridPosition, Quaternion.identity);
        }

    }
}
