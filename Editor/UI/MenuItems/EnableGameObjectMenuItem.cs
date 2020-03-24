using Innoactive.Creator.Core.Behaviors;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Behaviors
{
    /// <summary>
    /// Menu item which shows <see cref="EnableGameObjectBehavior"/> in the step inspector.
    /// </summary>
    public class EnableGameObjectMenuItem : StepInspectorMenu.Item<IBehavior>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get
            {
                return new GUIContent("Enable Object");
            }
        }

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new EnableGameObjectBehavior();
        }
    }
}
