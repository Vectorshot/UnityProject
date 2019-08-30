
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool flipped = false; //正转还是倒转
    public bool rotated = false;//是否相对相机旋转
    public float smooth = 60.0f; //旋转速度
    public float doorOpenAngle = -90f; //旋转角度


    private float sideFlip = -1;
    private float side = -1;
    private bool open = false; //当前状态
    private Vector3 defaultRotation;//初始旋转欧拉
    private Vector3 openRotation;//目标旋转欧拉

    //触发方法
    public void Startusing()
    {
        SetDoorRotation(transform.position);
        SetRotation();
        open = !open;
    }

    private void Start()
    {
        defaultRotation = transform.eulerAngles;
        SetRotation();
        sideFlip = (flipped ? 1 : -1);
    }

    private void Update()
    {
        if (open)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation), Time.deltaTime * smooth);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * smooth);
        }
    }

    //设置新的旋转
    private void SetRotation()
    {
        openRotation = new Vector3(defaultRotation.x, defaultRotation.y + (doorOpenAngle * (sideFlip * side)), defaultRotation.z);
    }

    //是否两面旋转，相机在哪人在哪（实验出来的在VR里）
    private void SetDoorRotation(Vector3 interacterPosition)
    {
        side = ((rotated == false && interacterPosition.z > transform.position.z) || (rotated == true && interacterPosition.x > transform.position.x) ? -1 : 1);
    }
}
