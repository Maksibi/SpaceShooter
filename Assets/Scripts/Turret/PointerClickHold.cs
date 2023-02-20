using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace SpaceShooter
{
    public class PointerClickHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool hold;
        public bool IsHold => hold;

        public void OnPointerDown(PointerEventData eventData)
        {
            hold = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            hold= false;
        }
    }
}
