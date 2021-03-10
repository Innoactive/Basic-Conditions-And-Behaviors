using System;
using Innoactive.Creator.Core.SceneObjects;

namespace Innoactive.Creator.Core.Properties
{
    /// <summary>
    /// Interface for <see cref="ISceneObjectProperty"/>s that can be used for teleport into.
    /// </summary>
    public interface ITeleportProperty : ISceneObjectProperty, ILockable
    {
        /// <summary>
        /// Emitted when an 'XR Rig' gets teleported into this <see cref="ISceneObject"/>.
        /// </summary>
        event EventHandler<EventArgs> Teleported;
        
        /// <summary>
        /// True if an XR Rig was teleported into this <see cref="ITeleportProperty"/>.
        /// </summary>
        bool WasUsedToTeleport { get; }
        
        /// <summary>
        /// Sets <see cref="WasUsedToTeleport"/> to true.
        /// </summary>
        /// <remarks>
        /// This method is called every time a <see cref="Conditions.TeleportCondition"/> is activate.
        /// </remarks>
        void Initialize();
        
        /// <summary>
        /// Instantaneously simulate that the object was used.
        /// </summary>
        void FastForwardTeleport();
    }
}
