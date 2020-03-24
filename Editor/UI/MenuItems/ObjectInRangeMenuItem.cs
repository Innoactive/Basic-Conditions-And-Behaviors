using Innoactive.Creator.Core.Conditions;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Conditions
{
    /// <summary>
    /// Menu item which shows <see cref="ObjectInRangeCondition"/> in the step inspector.
    /// </summary>
    public class ObjectInRangeMenuItem : StepInspectorMenu.Item<ICondition>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get
            {
                return new GUIContent("Object Nearby");
            }
        }

        /// <inheritdoc />
        public override ICondition GetNewItem()
        {
            return new ObjectInRangeCondition();
        }
    }
}
