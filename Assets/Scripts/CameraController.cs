using UnityEngine;
namespace SpaceShooter
{

    public class CameraController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Camera _camera;

        [SerializeField] private Transform target;

        [SerializeField] private float _InterpolationLinear, _InterpolationAngular, _ZOffset, _ForwardOffset;
        #endregion
        #region Unity Events
        private void FixedUpdate()
        {
            if (_camera == null | target == null) return;

            Vector2 CamPos = _camera.transform.position;
            Vector2 TargetPos = target.position + target.transform.up * _ForwardOffset;
            Vector2 newCamPos = Vector2.Lerp(CamPos, TargetPos, _InterpolationLinear * Time.deltaTime);

            _camera.transform.position = new Vector3(newCamPos.x, newCamPos.y, _ZOffset);

            if (_InterpolationAngular > 0)
            {
                _camera.transform.rotation = Quaternion.Slerp(_camera.transform.rotation, target.rotation, _InterpolationAngular * Time.deltaTime);
            }
        }
        #endregion
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}
