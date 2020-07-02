using System;
using Innoactive.Creator.Core.Behaviors;
using Innoactive.CreatorEditor.UI.StepInspector.Menu;

namespace Innoactive.CreatorEditor.UI.Behaviors
{
    /// <inheritdoc />
    [Obsolete("Locking scene objects is obsoleted, consider using property locking.")]
    public class UnlockObjectMenuItem : MenuItem<IBehavior>
    {
        /// <inheritdoc />
        public override string DisplayedName { get; } = "Unlock Object";

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new UnlockObjectBehavior();
        }
    }
}
