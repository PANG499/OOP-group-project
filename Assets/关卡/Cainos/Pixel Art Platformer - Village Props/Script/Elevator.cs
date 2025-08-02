using UnityEngine;



public class Elevator : MonoBehaviour
{
    // �� Unity �༭�������õı���
    public Transform topPoint;      // �����ƶ��Ķ���
    public Transform bottomPoint;   // �����ƶ��ĵ׵�
    public float speed = 3.0f;      // �����ƶ��ٶ�

    // ˽�б���
    private Transform target;       // ���ݵ�ǰ��Ŀ���

    void Start()
    {
        // ��Ϸ��ʼʱ���õ������ƶ����͵�
        transform.position = bottomPoint.position;
        // Ȼ�����õ�һ��Ŀ��Ϊ����
        target = topPoint;
    }

    void Update()
    {
        // ʹ�� Vector3.MoveTowards ƽ���ؽ������ƶ���Ŀ���
        // �����ֱ��ǣ���ǰλ��, Ŀ��λ��, ÿ���ƶ���������
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // �������Ƿ��Ѿ��ǳ��ӽ�Ŀ���
        // Vector3.Distance ����������֮��ľ���
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // �����ǰĿ���Ƕ��㣬��ô��һ��Ŀ��ͻ��ɵ׵�
            if (target == topPoint)
            {
                target = bottomPoint;
            }
            // �����ǰĿ���ǵ׵㣬��ô��һ��Ŀ��ͻ��ɶ���
            else
            {
                target = topPoint;
            }
        }
    }
}