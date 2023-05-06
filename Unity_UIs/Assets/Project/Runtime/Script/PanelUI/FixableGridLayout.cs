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
        // ���������� ���ڸ� ������ �� �ִ�.
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

            // ���� �ڽ� ������Ʈ ������ ������
            float sqrRt = Mathf.Sqrt(transform.childCount);

            rows = Mathf.CeilToInt(sqrRt);
            colums = Mathf.CeilToInt(sqrRt);
        }

        if(fitType == FitType.Width || fitType == FitType.FixedColums) rows = Mathf.CeilToInt(transform.childCount / (float)colums);
        if(fitType == FitType.Height || fitType == FitType.FixedRows) colums = Mathf.CeilToInt(transform.childCount / (float)rows);

        // rect �� ����,���ΰ� ��������
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        // (parentWidth / (float)colums) - ��ġ�� ������ ����
        // (spacing.x / (float)colums) - ������ ���� ������ �Ÿ�
        // (padding.left / (float)colums)-(padding.right / (float)colums)  - �е���
        float cellWidth = (parentWidth / (float)colums) - ((spacing.x / (float)colums) * 2) - (padding.left / (float)colums) - (padding.right / (float)colums);
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * 2) - (padding.top / (float)rows) - (padding.bottom / (float)rows);

        // fit�� ���������� rect�� ũ�⸸ŭ ����, �׷��� ������ ������ ũ�⸸ŭ ����
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

            // (cellSize.x * columCount) - ��ġ�� ������ ���� 
            // (spacing.x * columCount) - ���� �� ���� ������ �Ÿ�
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
