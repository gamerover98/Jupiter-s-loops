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

        [Tooltip("When the player enters in contact with a meteor")]
        public UnityEvent meteorCollisionEvent = new();
        
        [Tooltip("When the player enters in contact with a capsule")]
        public UnityEvent capsuleCollisionEvent = new();

        [Tooltip("When the player enters in contact with a wall")]
        public UnityEvent wallCollisionEvent = new();
    }
}