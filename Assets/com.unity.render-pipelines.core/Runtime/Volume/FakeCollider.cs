namespace UnityEngine.Experimental.Rendering
{
    internal class FakeCollider
    {
        public bool enabled;
        public Bounds bounds;
        public float radius;
        public Vector3 center, size;

        public Vector3 ClosestPoint(Vector3 point)
        {
            return bounds.ClosestPoint(point);
        }
    }
}