using UnityEngine;
using UnityEngine.Events;

namespace Mono.Manager
{
    public class EventManager : MonoBehaviour
    {
        [Tooltip("When the initial game countdown starts")]
        public UnityEvent startingCountdownStartEvent = new();
        
        [Tooltip("When the initial game countdown reaches zero")]
        public UnityEvent startingCountdownEndEvent = new();
        
        [Tooltip("When the game starts and the player can move")]
        public UnityEvent playingStartEvent = new();
        
        [Tooltip("When the game enters in pause mode")]
        public UnityEvent playingPauseEvent = new();
        
        [Tooltip("When the game ends")]
        public UnityEvent playingEndEvent = new();
    }
}