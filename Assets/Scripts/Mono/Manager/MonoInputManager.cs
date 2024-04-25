using Api.Manager;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoInputManager : MonoBehaviour, IInputManager
    {
        private const string VerticalAxisName = "Vertical";
        private const string HorizontalAxisName = "Horizontal";
        
        private float verticalThreshold;
        private float horizontalThreshold;
        
        public float GetVerticalThreshold() => verticalThreshold;
        public float GetHorizontalThreshold() => horizontalThreshold;

        protected void Update()
        {
            verticalThreshold = Input.GetAxis(VerticalAxisName);
            horizontalThreshold = Input.GetAxis(HorizontalAxisName);
        }
    }
}