using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    public GameObject platformSegmentPrefab;
    public float pointSpacing = 0.2f; // space between line points
    public float segmentThickness = 0.2f;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    private bool isDrawing = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            points.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], mousePos) >= pointSpacing)
            {
                points.Add(mousePos);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPosition(points.Count - 1, mousePos);
            }
        }

        if (Input.GetMouseButtonUp(0) && isDrawing)
        {
            isDrawing = false;
            SpawnPlatformSegments();
        }
    }

    void SpawnPlatformSegments()
    {
        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector3 start = points[i];
            Vector3 end = points[i + 1];
            Vector3 mid = (start + end) / 2f;
            float distance = Vector3.Distance(start, end);
            float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * Mathf.Rad2Deg;

            GameObject segment = Instantiate(platformSegmentPrefab, mid, Quaternion.Euler(0, 0, angle));
            segment.transform.localScale = new Vector3(distance, segmentThickness, 1f);
        }
    }
}