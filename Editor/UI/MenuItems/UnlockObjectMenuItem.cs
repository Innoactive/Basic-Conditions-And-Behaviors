using Innoactive.Creator.Core.Behaviors;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Behaviors
{
    /// <summary>
    /// Menu item which shows <see cref="UnlockObjectBehavior"/> in the step inspector.
    /// </summary>
    public class UnlockObjectMenuItem : StepInspectorMenu.Item<IBehavior>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get
            {
                return new GUIContent("Unlock Object");
            }
        }

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new UnlockObjectBehavior();
        }
    }
}
