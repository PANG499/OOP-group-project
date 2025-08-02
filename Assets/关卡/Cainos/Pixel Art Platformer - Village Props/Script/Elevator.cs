using UnityEngine;



public class Elevator : MonoBehaviour
{
    // 在 Unity 编辑器中设置的变量
    public Transform topPoint;      // 电梯移动的顶点
    public Transform bottomPoint;   // 电梯移动的底点
    public float speed = 3.0f;      // 电梯移动速度

    // 私有变量
    private Transform target;       // 电梯当前的目标点

    void Start()
    {
        // 游戏开始时，让电梯先移动到低点
        transform.position = bottomPoint.position;
        // 然后设置第一个目标为顶点
        target = topPoint;
    }

    void Update()
    {
        // 使用 Vector3.MoveTowards 平滑地将电梯移动到目标点
        // 参数分别是：当前位置, 目标位置, 每秒移动的最大距离
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // 检查电梯是否已经非常接近目标点
        // Vector3.Distance 计算两个点之间的距离
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // 如果当前目标是顶点，那么下一个目标就换成底点
            if (target == topPoint)
            {
                target = bottomPoint;
            }
            // 如果当前目标是底点，那么下一个目标就换成顶点
            else
            {
                target = topPoint;
            }
        }
    }
}