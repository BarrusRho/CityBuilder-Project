using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder
{
    public class CameraMovement : MonoBehaviour
    {
        private Vector3? _basePointPosition = null;
        private int _cameraXMin, _cameraXMax, _cameraZMin, _cameraZMax;
        public float CameraMovementSpeed = 0.05f;

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void MoveCamera(Vector3 pointerPosition)
        {
            if (_basePointPosition.HasValue == false)
            {
                _basePointPosition = pointerPosition;
            }
            Vector3 newPosition = pointerPosition - _basePointPosition.Value;
            newPosition = new Vector3(newPosition.x, 0, newPosition.y);
            transform.Translate(newPosition * CameraMovementSpeed);
            LimitPositionInsideCameraBounds();
        }

        private void LimitPositionInsideCameraBounds()
        {
            transform.position = new Vector3(
                            Mathf.Clamp(transform.position.x, _cameraXMin, _cameraXMax)
                            , 0
                            , Mathf.Clamp(transform.position.z, _cameraZMin, _cameraZMax)
                            );
        }

        public void StopCameraMovement()
        {
            _basePointPosition = null;
        }

        public void SetCameraLimits(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax)
        {
            this._cameraXMax = cameraXMax;
            this._cameraXMin = cameraXMin;
            this._cameraZMax = cameraZMax;
            this._cameraZMin = cameraZMin;
        }
    }
}
