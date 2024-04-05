using JetBrains.Annotations;

namespace Api
{
    public interface IPortal
    {
        /// <summary>
        /// Get the type of the current portal.
        /// </summary>
        /// <returns>PortalType.Entry or PortalType.Exit</returns>
        PortalType GetPortalType();

        /// <summary>
        /// If the portal type is Exit, the destination must be an entry portal type instance.
        /// </summary>
        /// <returns></returns>
        [CanBeNull] IPortal GetDestinationPortal();

        /// <summary>
        /// If the portal has a destination.
        /// </summary>
        /// <returns>True if the destination is not null.</returns>
        bool HasDestination() => GetDestinationPortal() != null;
    }
    
    public enum PortalType
    {
        /// <summary>
        /// The Entry portal type.
        /// </summary>
        Entry,
        
        /// <summary>
        /// The Exit portal type.
        /// </summary>
        Exit
    }
}