using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CityBuilder
{
    public class InputManager : MonoBehaviour
    {
        public LayerMask MouseInputMask;
        //public GameObject BuildingPrefab;
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
                }
            }
        }

        /*private void CreateBuilding(Vector3 gridPosition)
        {
            Instantiate(BuildingPrefab, gridPosition, Quaternion.identity);
        }*/
    }

}
