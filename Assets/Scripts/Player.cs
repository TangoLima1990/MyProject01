using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     private Vector3 touchStartPosition;
    private Vector3 touchEndPosition;
    private float swipeThreshold = 50f;

    void Update()
    {
        // Kiểm tra xem người dùng có chạm vào màn hình không
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Lấy touch đầu tiên

            // Xác định hành động của người dùng
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position; // Lấy vị trí bắt đầu khi người dùng bắt đầu chạm
                    break;
                case TouchPhase.Ended:
                    touchEndPosition = touch.position; // Lấy vị trí kết thúc khi người dùng kết thúc chạm
                    CheckSwipe(); // Kiểm tra nếu đó là một swipe và thực hiện hành động di chuyển tương ứng
                    break;
            }
        }
    }

    void CheckSwipe()
    {
        // Tính toán khoảng cách giữa vị trí bắt đầu và vị trí kết thúc
        float deltaX = touchEndPosition.x - touchStartPosition.x;
        float deltaY = touchEndPosition.y - touchStartPosition.y;

        // Kiểm tra xem có đạt được ngưỡng swipe không
        if (Mathf.Abs(deltaX) > swipeThreshold || Mathf.Abs(deltaY) > swipeThreshold)
        {
            // Nếu swipe theo hướng ngang, di chuyển object theo trục X
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    transform.Translate(Vector3.right);
                }
                else
                {
                    transform.Translate(Vector3.left);
                }
            }
            // Nếu swipe theo hướng dọc, di chuyển object theo trục Z (hoặc Y tùy vào bố cục của game)
            else
            {
                if (deltaY > 0)
                {
                    transform.Translate(Vector3.forward);
                }
                else
                {
                    transform.Translate(Vector3.back);
                }
            }
        }
    }
    
}
