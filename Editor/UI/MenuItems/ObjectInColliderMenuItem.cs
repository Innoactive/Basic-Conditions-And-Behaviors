using Innoactive.Creator.Core.Conditions;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Conditions
{
    /// <summary>
    /// Menu item which shows <see cref="ObjectInColliderCondition"/> in the step inspector.
    /// </summary>
    public class ObjectInColliderMenuItem : StepInspectorMenu.Item<ICondition>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get
            {
                return new GUIContent("Move Object into Collider");
            }
        }

        /// <inheritdoc />
        public override ICondition GetNewItem()
        {
            return new ObjectInColliderCondition();
        }
    }
}
