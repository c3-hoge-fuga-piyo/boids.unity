using UnityEngine;
using UnityEngine.Assertions;

using System.Collections.Generic;

namespace OhanaYa.Boids
{
    using Events;

    public sealed class BoidAgent : MonoBehaviour
        , IBoid
        , IBoidFoundHandler
        , IBoidLostHandler
    {
        #region Serialized Properties
        [SerializeField]
        float speed = 3.5f;
        public float Speed
        {
            get { return this.speed; }
            set { this.speed = Mathf.Max(value, 0); }
        }

        [SerializeField]
        float angularSpeed = 120f;
        public float AngularSpeed
        {
            get { return this.angularSpeed; }
            set { this.angularSpeed = Mathf.Max(value, 0); }
        }

        [SerializeField]
        Rules.BoidRule[] rules;
        #endregion

        #region Unity Events
        void Update()
        {
            foreach (var rule in this.rules)
            {
                this.Steer(rule.Evaluate(this));
            }
        }

        void LateUpdate()
        {
            if (this.direction.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            this.direction.Normalize();

            var t = this.Transform;

            var deltaTime = Time.deltaTime;

            // Rotation
            var rotateFrom = t.rotation;
            var rotateTo = Quaternion.LookRotation(this.direction);
            var deltaAngle = this.AngularSpeed * deltaTime;
            var rotation = Quaternion.RotateTowards(rotateFrom, rotateTo, deltaAngle);

            // Position
            var distance = this.Speed * deltaTime;
            var deltaPosition = rotation * (Vector3.forward * distance);
            var position = t.position + deltaPosition;

            // Apply
            t.SetPositionAndRotation(position, rotation);

            // Reset
            this.direction = Vector3.zero;
        }

        #if UNITY_EDITOR
        void OnValidate()
        {
            this.Speed = this.speed;
            this.AngularSpeed = this.angularSpeed;
        }
        #endif
        #endregion

        #region Boid Events
        void IBoidFoundHandler.OnBoidFound(IBoid boid)
        {
            Assert.AreNotEqual(this, boid);
            Assert.IsFalse(this.Neighbors.Contains(boid));

            this.Neighbors.Add(boid);
        }

        void IBoidLostHandler.OnBoidLost(IBoid boid)
        {
            Assert.AreNotEqual(this, boid);
            Assert.IsTrue(this.Neighbors.Contains(boid));

            this.Neighbors.Remove(boid);
        }
        #endregion

        #region Caches
        Transform cachedTransform;
        #endregion

        Vector3 direction;

        public void Steer(Vector3 direction)
        {
            this.direction += direction;
        }

        #region IBoid
        public Transform Transform
            => this.cachedTransform ? this.cachedTransform : (this.cachedTransform = this.transform);

        public List<IBoid> Neighbors { get; } = new List<IBoid>();
        #endregion
    }
}