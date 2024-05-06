using System;
using Api.Manager;
using UnityEngine;

namespace Mono.Manager
{
    public class MonoInputManager : MonoBehaviour, IInputManager
    {
        public delegate void EscapeKeyPress();

        public delegate void SpaceKeyPress();

        public static event EscapeKeyPress EscapeKeyPressed;
        public static event SpaceKeyPress SpaceKeyPressed;

        private const string VerticalAxisName = "Vertical";
        private const string HorizontalAxisName = "Horizontal";


        /// <summary>
        /// Enable or disable vertical and horizontal movements.
        /// <para>By default its value is false.</para>
        /// </summary>
        [NonSerialized] public bool ActivePlayerMovements;

        private float verticalThreshold;
        private float horizontalThreshold;

        protected void Update()
        {
            verticalThreshold = Input.GetAxis(VerticalAxisName);
            horizontalThreshold = Input.GetAxis(HorizontalAxisName);

            if (Input.GetKeyDown(KeyCode.Escape)) EscapeKeyPressed?.Invoke();
            if (Input.GetKeyDown(KeyCode.Space)) SpaceKeyPressed?.Invoke();
        }

        /// <summary>
        /// Returns the value of the vertical axis.
        /// <para>Value range [-1, +1]</para>
        /// </summary>
        public float GetVerticalThreshold() => verticalThreshold;

        /// <summary>
        /// Returns the value of the horizontal axis.
        /// <para>Value range [-1, +1]</para>
        /// </summary>
        public float GetHorizontalThreshold() => horizontalThreshold;
    }
}