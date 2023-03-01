using UnityEngine;

namespace SpaceShooter
{
    public class InputController : MonoBehaviour
    {
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }
        #region Editor Fields
        [SerializeField] private SpaceShip m_TargetShip;
        public void SetTargetShip(SpaceShip ship) => m_TargetShip = ship;

        [SerializeField] private VirtualJoystick m_Joystick;

        [SerializeField] private ControlMode m_controlMode;

        [SerializeField] private PointerClickHold mobileFirePrimary, mobileFireSecondary;

        [SerializeField] private PauseMenuController pauseMenu;
        #endregion
        #region Unity Events
        private void Start()
        {
            if (Application.isMobilePlatform)
            {
                m_controlMode = ControlMode.Mobile;
                m_Joystick.gameObject.SetActive(true);
                mobileFirePrimary.gameObject.SetActive(true);
                mobileFireSecondary.gameObject.SetActive(true);
            }
            else
            {
                m_controlMode = ControlMode.Keyboard;
                m_Joystick.gameObject.SetActive(false);
                mobileFirePrimary.gameObject.SetActive(false);
                mobileFireSecondary.gameObject.SetActive(false);
            }
        }
        private void Update()
        {
            if (m_TargetShip == null) return;
            if (m_controlMode == ControlMode.Keyboard) ControlKeyboard();
            if (m_controlMode == ControlMode.Mobile) ControlMobile();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseMenu.isPaused)
                {
                    pauseMenu.OnButtonContinue();
                }
                else pauseMenu.OnButtonShowPause();
            }

#if UNITY_EDITOR
            if (m_controlMode == ControlMode.Mobile) m_Joystick.gameObject.SetActive(true); //”¡–¿“‹
#endif
        }
        #endregion
        #region Private API
        private void ControlMobile()
        {
            var dir = m_Joystick.Value;

            m_TargetShip.ThrustControl = dir.y;
            m_TargetShip.TorqueControl = -dir.x;


            if (mobileFirePrimary.IsHold) m_TargetShip.Fire(TurretMode.Primary);
            if (mobileFireSecondary.IsHold) m_TargetShip.Fire(TurretMode.Secondary);
        }
        private void ControlKeyboard()
        {
            float thrust = 0.0f;
            float torque = 0.0f;

            if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W)) thrust = 1.0f;
            if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S)) thrust = -1.0f;
            if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A)) torque = 1.0f;
            if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D)) torque = -1.0f;

            m_TargetShip.ThrustControl = thrust;
            m_TargetShip.TorqueControl = torque;


            if (Input.GetKey(KeyCode.Space)) m_TargetShip.Fire(TurretMode.Primary);
            if (Input.GetKey(KeyCode.LeftControl)) m_TargetShip.Fire(TurretMode.Secondary);
        }
        #endregion
    }
}