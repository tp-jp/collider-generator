using UnityEngine;

namespace TpLab.ColliderGenerator
{
    public class ColliderGenerator : MonoBehaviour
    {
        [Tooltip("コライダーを配置する範囲X")]
        public float layoutSizeX;

        [Tooltip("コライダーを配置する範囲Z")]
        public float layoutSizeZ;

        [Tooltip("コライダーを配置する数")]
        public int layoutCount;

        [Tooltip("コライダーの厚み")]
        public float colliderThickness;

        [Tooltip("コライダーの高さ")]
        public float colliderHeight;

        [Tooltip("コライダーの辺の長さ")]
        public float colliderEdgeLength;

        [Tooltip("コライダーの名前書式")]
        public string colliderNameFormat = "BoxCollider_{0}";

        class LayoutInfo
        {
            public Vector3 position;
            public Quaternion rotation;
            public float edgeLength;
        }

        /// <summary>
        /// オブジェクト選択時に描画するギズモ。
        /// </summary>
        void OnDrawGizmosSelected()
        {
            var cache = Gizmos.matrix;
            var vertices = CalculateLayoutVertices();
            for (int i = 0; i < layoutCount; i++)
            {
                var boxColliderInfo = CreateLayoutInfo(vertices[i], vertices[(i + 1) % layoutCount]);
                Gizmos.matrix = Matrix4x4.TRS(boxColliderInfo.position, boxColliderInfo.rotation, Vector3.one);
                Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
                Gizmos.DrawCube(Vector3.zero, new Vector3(colliderHeight, colliderThickness, boxColliderInfo.edgeLength));
            }
            Gizmos.matrix = cache;
        }

        /// <summary>
        /// コライダーを生成する。
        /// </summary>
        public void GenerateBoxColliders()
        {
            ClearBoxColliders();
            var vertices = CalculateLayoutVertices();
            for (int i = 0; i < layoutCount; i++)
            {
                var boxColliderInfo = CreateLayoutInfo(vertices[i], vertices[(i + 1) % layoutCount]);

                // ボックスコライダーオブジェクトを作成
                var boxColliderObject = new GameObject(string.Format(colliderNameFormat, i));
                boxColliderObject.transform.SetParent(transform);
                boxColliderObject.transform.position = boxColliderInfo.position;
                boxColliderObject.transform.rotation = boxColliderInfo.rotation;

                // ボックスコライダーコンポーネントを追加
                var boxCollider = boxColliderObject.AddComponent<BoxCollider>();
                boxCollider.size = new Vector3(colliderHeight, colliderThickness, boxColliderInfo.edgeLength);
            }
        }

        /// <summary>
        /// コライダーをクリアする。
        /// </summary>
        public void ClearBoxColliders()
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// コライダーを配置する頂点を計算する。
        /// </summary>
        /// <returns>頂点一覧</returns>
        Vector3[] CalculateLayoutVertices()
        {
            var vertices = new Vector3[layoutCount];
            var angleIncrement = 360f / layoutCount;
            for (var i = 0; i < layoutCount; i++)
            {
                var angle = i * angleIncrement * Mathf.Deg2Rad;
                var x = Mathf.Cos(angle) * (layoutSizeX + colliderThickness) * 0.5f;
                var y = colliderHeight * 0.5f;
                var z = Mathf.Sin(angle) * (layoutSizeZ + colliderThickness) * 0.5f;
                vertices[i] = new Vector3(x, y, z);
            }
            return vertices;
        }

        /// <summary>
        /// 頂点情報からレイアウト情報を生成する。
        /// </summary>
        /// <param name="pointA">頂点A</param>
        /// <param name="pointB">頂点B</param>
        /// <returns>レイアウト情報</returns>
        LayoutInfo CreateLayoutInfo(Vector3 pointA, Vector3 pointB)
        {
            var edgeVector = pointB - pointA;
            var edgeDirection = edgeVector.normalized;
            return new LayoutInfo()
            {
                position = transform.position + (pointA + pointB) * 0.5f,
                rotation = Quaternion.LookRotation(edgeDirection, Vector3.forward),
                edgeLength = colliderEdgeLength > 0 ? colliderEdgeLength : edgeVector.magnitude,
            };
        }
    }
}
