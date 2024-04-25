namespace Api.Entity
{
    public interface ICamera<TVector2>
    {
        /// <summary>Change the camera position.</summary>
        /// <param name="position">The new camera position.</param>
        void Teleport(TVector2 position);
        
        /// <summary>Sets the camera velocity.</summary>
        /// <param name="velocity">The new camera velocity.</param>
        void SetVelocity(TVector2 velocity);

        /// <summary>Gets the camera velocity.</summary>
        /// <returns>The Vector velocity instance.</returns>
        TVector2 GetVelocity();
    }
}