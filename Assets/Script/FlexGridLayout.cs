// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FlexGridLayout : LayoutGroup
// {
//     public int rows;
//     public int columns;
//     public Vector2 cellSize;
//     public Vector2 spacing;
//     public Vector2 padding;

//     public override void CalculateLayoutInputHorizontal()
//     {
//         base.CalculateLayoutInputHorizontal();

//         float sqrRt = Mathf.sqrRt(transform.childCount);
//         rows = Mathf.CeilToInt(sqrRt);
//         columns = Mathf.CeilToInt(sqrRt);

//         float parentWidth = rectTransform.rect.width;
//         float parentHeight = rectTransform.rect.height;

//         float cellWidth = (parentWidth / (float)columns) - ((spacing.x / (float)columns) * 2) - (padding.left / (float)columns) - (padding.right / (float)columns);
//         float CellHeight = (parentHeight / (float)columns)  - ((spacing.x / (float)rows) * 2) - (padding.top / (float)rows) - (padding.bottom / (float)rows);

//         cellSize.x = cellWidth;
//         cellSize.y = CellHeight;

//         int columnCount = 0;
//         int rowCount = 0;

//         for (int i = 0; i < rectChildren.Count; i++) {
//             rowCount = i / columns;
//             columnCount = i % columns;

//             var item = rectChildren[i];

//             var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
//             var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

//             SetChildAlongAxis(item, 0, xPos, cellSize.x);
//             SetChildAlongAxis(item, 1, yPos, cellSize.y);
//         }
        
//     }
// }
