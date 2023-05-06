using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;                       // LayoutGroup

[AddComponentMenu("CustomUI/FixableGridLayout")]
public class FixableGridLayout : LayoutGroup
{
    public enum FitType
    { 
        Uniform,
        Width,
        Height,
        // 직접적으로 숫자를 선택할 수 있다.
        FixedRows,
        FixedColums
    }

    [Header("Fit Setting")]
    public FitType fitType;

    [Header("X , Y")]
    public int rows;
    public int colums;
    [Header("Spacing")]
    public Vector2 cellSize;
    public Vector2 spacing;

    [Header("Rect Fit ( only for FixedRows, FixedColums )")]
    public bool fitX;
    public bool fitY;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if((fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform))
        {
            fitX = true;
            fitY = true; 

            // 현재 자식 오브젝트 갯수의 제곱값
            float sqrRt = Mathf.Sqrt(transform.childCount);

            rows = Mathf.CeilToInt(sqrRt);
            colums = Mathf.CeilToInt(sqrRt);
        }

        if(fitType == FitType.Width || fitType == FitType.FixedColums) rows = Mathf.CeilToInt(transform.childCount / (float)colums);
        if(fitType == FitType.Height || fitType == FitType.FixedRows) colums = Mathf.CeilToInt(transform.childCount / (float)rows);

        // rect 의 가로,세로값 가져오기
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        // (parentWidth / (float)colums) - 배치될 도형의 길이
        // (spacing.x / (float)colums) - 도형과 도형 사이의 거리
        // (padding.left / (float)colums)-(padding.right / (float)colums)  - 패딩값
        float cellWidth = (parentWidth / (float)colums) - ((spacing.x / (float)colums) * 2) - (padding.left / (float)colums) - (padding.right / (float)colums);
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * 2) - (padding.top / (float)rows) - (padding.bottom / (float)rows);

        // fit이 켜져있으면 rect의 크기만큼 설정, 그렇지 않으면 도형의 크기만큼 설정
        cellSize.x = fitX ?  cellWidth : cellSize.x;
        cellSize.y = fitY ?  cellHeight : cellSize.y;

        float tempX = 0;
        for(int i= 0; i<rectChildren.Count; i++)
        {
            var item = rectChildren[i];
            if (item.GetComponent<LayoutElement>()) tempX += item.GetComponent<LayoutElement>().preferredWidth;
        }

        int columCount = 0, rowCount = 0;
        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / colums;
            columCount = i % colums;

            var item = rectChildren[i];

            // (cellSize.x * columCount) - 배치될 도형의 갯수 
            // (spacing.x * columCount) - 도형 과 도형 사이의 거리
            var xPos = (cellSize.x * columCount) + (spacing.x * columCount) + padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {

    }

    public override void SetLayoutHorizontal()
    {

    }

    public override void SetLayoutVertical()
    {

    }
}
