using UnityEngine;
using UnityEngine.Assertions;

namespace OhanaYa.Boids
{
    public sealed class BoidSpawner : MonoBehaviour
    {
        #region Serialized Properties
        [SerializeField]
        BoidAgent original;

        [SerializeField]
        int spawnCount;

        [SerializeField]
        Transform[] regionVertices;

        [SerializeField]
        Transform center;
        #endregion

        #region Unity Events
        void Awake()
        {
            var min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            var max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            foreach (var v in this.regionVertices)
            {
                min = Vector3.Min(min, v.position);
                max = Vector3.Max(max, v.position);

                v.forward = (this.center.position - v.position).normalized;
            }

            for (var i = 0; i < this.spawnCount; ++i)
            {
                var x = Random.Range(min.x, max.x);
                var y = Random.Range(min.y, max.y);
                var z = Random.Range(min.z, max.z);

                var position = new Vector3(x, y, z);

                Instantiate(this.original, position, Quaternion.identity);
            }
        }
        #endregion
    }
}