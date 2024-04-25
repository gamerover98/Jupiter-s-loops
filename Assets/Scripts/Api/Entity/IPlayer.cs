namespace Api.Entity
{
    public interface IPlayer<TVector2, out TCamera> : IEntity<TVector2>, ILiving<int>
        where TCamera : ICamera<TVector2>
    {
        /// <summary>The player camera</summary>
        /// <returns>Te player camera instance.</returns>
        TCamera GetCamera();
    }
}