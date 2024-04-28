namespace Api.Common
{
    /// <summary>Represents an object that can be triggered with another object.</summary>
    /// <typeparam name="TTrigger">The type of the trigger object.</typeparam>
    public interface ITriggerable<in TTrigger>
    {
        /// <summary>Called when this object collides with another collider object.</summary>
        /// <param name="withObject">The other object with witch this object is triggered.</param>
        void OnTrigger(TTrigger withObject);
    }
}