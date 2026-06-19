using UnityEngine;
using UnityEngine.UI;

namespace SpeedDrop.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasRenderer))]
    public sealed class CrosshairPresenter : MaskableGraphic
    {
        [SerializeField] private float lineLength = 28f;
        [SerializeField] private float lineThickness = 2f;

        protected override void OnValidate()
        {
            lineLength = Mathf.Max(0f, lineLength);
            lineThickness = Mathf.Max(1f, lineThickness);

            if (TryGetComponent(out CanvasRenderer _))
            {
                SetVerticesDirty();
            }
        }

        protected override void OnPopulateMesh(VertexHelper vertexHelper)
        {
            vertexHelper.Clear();

            float halfLength = lineLength * 0.5f;
            float halfThickness = lineThickness * 0.5f;

            AddRect(vertexHelper, -halfThickness, -halfLength, halfThickness, halfLength);
            AddRect(vertexHelper, -halfLength, -halfThickness, halfLength, halfThickness);
        }

        private void Reset()
        {
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = new Vector2(lineLength, lineLength);
            raycastTarget = false;
            color = new Color(1f, 1f, 1f, 0.9f);
        }

        private void AddRect(VertexHelper vertexHelper, float left, float bottom, float right, float top)
        {
            int startIndex = vertexHelper.currentVertCount;
            Color32 vertexColor = color;

            vertexHelper.AddVert(new Vector3(left, bottom, 0f), vertexColor, Vector2.zero);
            vertexHelper.AddVert(new Vector3(left, top, 0f), vertexColor, Vector2.up);
            vertexHelper.AddVert(new Vector3(right, top, 0f), vertexColor, Vector2.one);
            vertexHelper.AddVert(new Vector3(right, bottom, 0f), vertexColor, Vector2.right);

            vertexHelper.AddTriangle(startIndex, startIndex + 1, startIndex + 2);
            vertexHelper.AddTriangle(startIndex + 2, startIndex + 3, startIndex);
        }
    }
}
