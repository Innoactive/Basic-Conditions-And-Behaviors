using System;
using Innoactive.Creator.Core.SceneObjects;

namespace Innoactive.Creator.Core.Properties
{
    /// <summary>
    /// Interface for <see cref="ISceneObject"/>s that can be used for teleport into.
    /// </summary>
    public interface ITeleportProperty : ISceneObjectProperty, ILockable
    {
        /// <summary>
        /// Emitted when an 'XR Rig' gets teleported into this <see cref="ISceneObject"/>.
        /// </summary>
        event EventHandler<EventArgs> Teleported;
        
        /// <summary>
        /// Is object currently used.
        /// </summary>
        bool WasUsedToTeleport { get; }
        
        /// <summary>
        /// Instantaneously simulate that the object was used.
        /// </summary>
        void FastForwardTeleport();
    }
}