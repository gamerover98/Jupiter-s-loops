using UnityEngine;
using UnityEngine.Events;

namespace Mono.Manager
{
    public class EventManager : MonoBehaviour
    {
        [Tooltip("When the initial game countdown reaches zero")]
        public UnityEvent startingCountdownEndEvent = new();
    }
}