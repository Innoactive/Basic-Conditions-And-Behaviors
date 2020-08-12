using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using Innoactive.Creator.Core.Attributes;
using Innoactive.Creator.Core.SceneObjects;
using Innoactive.Creator.Core.Utils;

namespace Innoactive.Creator.Core.Behaviors
{
    /// <summary>
    /// Behavior that repositions target SceneObject to the position and rotation of another TargetObject.
    /// </summary>
    [DataContract(IsReference = true)]
    public class RepositionBehavior : Behavior<RepositionBehavior.EntityData>
    {
        /// <summary>
        /// The "reposition object" behavior's data.
        /// </summary>
        [DisplayName("Reposition Object")]
        [DataContract(IsReference = true)]
        public class EntityData : IBehaviorData
        {
            /// <summary>
            /// ObjectToReposition scene object to be repositioned.
            /// </summary>
            [DataMember]
            [DisplayName("Object to reposition")]
            public SceneObjectReference ObjectToReposition { get; set; }

            /// <summary>
            /// The new position that the object will get
            /// </summary>
            [DataMember]
            [DisplayName("The new position")]
            public SceneObjectReference PositionProvider { get; set; }

            /// <summary>
            /// The new rotation can be set
            /// </summary>
            [DataMember]
            [DisplayName("The new rotation")]
            public Vector3 RotationProvider { get; set; }

            /// <inheritdoc />
            public Metadata Metadata { get; set; }

            /// <inheritdoc />
            public string Name { get; set; }
        }

        private class ActivatingProcess : Process<EntityData>
        {

            public ActivatingProcess(EntityData data) : base(data)
            {
            }

            /// <inheritdoc />
            public override void Start()
            {
                Transform targetPositionTransform = Data.PositionProvider.Value.GameObject.transform;
                Transform objectToRepositionTransform = Data.ObjectToReposition.Value.GameObject.transform;

                objectToRepositionTransform.position = targetPositionTransform.position;

                objectToRepositionTransform.localEulerAngles = Data.RotationProvider;
            }

            public override IEnumerator Update()
            {
                yield break;
            }

            public override void End()
            {
            }

            public override void FastForward()
            {
            }
        }

        public RepositionBehavior() : this("", "", "")
        {
        }

        public RepositionBehavior(ISceneObject @object, ISceneObject positionProvider, ISceneObject rotationProvider, float duration) : this(TrainingReferenceUtils.GetNameFrom(@object), TrainingReferenceUtils.GetNameFrom(rotationProvider),TrainingReferenceUtils.GetNameFrom(positionProvider))
        {
        }

        public RepositionBehavior(string objectName, string positionProviderName, string rotationProviderName, string name = "Reposition Object")
        {
            Data.ObjectToReposition = new SceneObjectReference(objectName);
            Data.PositionProvider = new SceneObjectReference(positionProviderName);
            Data.RotationProvider = default;
            Data.Name = name;
        }

        /// <inheritdoc />
        public override IProcess GetActivatingProcess()
        {
            return new ActivatingProcess(Data);
        }
    }
}
