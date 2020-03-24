using Innoactive.Creator.Core.Behaviors;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Behaviors
{
    /// <summary>
    /// Menu item which shows <see cref="DelayBehavior"/> in the step inspector.
    /// </summary>
    public class DelayMenuItem : StepInspectorMenu.Item<IBehavior>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get { return new GUIContent("Delay"); }
        }

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new DelayBehavior();
        }
    }
}
