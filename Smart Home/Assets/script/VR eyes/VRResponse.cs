using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����ʵ�ֽ����������߼��
/// ���裺
/// 1.�ӵ�ǰλ����ǰ��һ�����ߣ�����Զ��
/// 2.������������󣬽����жϣ��ж�ѡ���е������Ƿ񱻴�����
/// 3.�������ߵ������ж���ʲô����
/// 4.�����߼�����Ϣ���ݳ�ȥ
/// </summary>
public class VRResponse : MonoBehaviour
{

    #region �������ֶλ�������

    /// <summary>
    /// ������ʱ�����仯��Image
    /// </summary>
    private Image waitingImage;

    /// <summary>
    /// �����Ƿ����
    /// </summary>
    private bool isHovered = false;

    /// <summary>
    /// ���߼�⵽���������Ϣ
    /// </summary>
    private RaycastHit hitInfo;

    /// <summary>
    /// ���߼�⵽�����������
    /// </summary>
    private string hitInfoName;

    /// <summary>
    /// ���߼�⵽�������Transform
    /// </summary>
    private Transform hitInfoTrans;

    /// <summary>
    /// UIѡ�������ʱ�����ȴ���ʱ��
    /// </summary>
    private float enterTime;

    /// <summary>
    /// ѡ���е�����
    /// </summary>
    private VRComponent selectComponent;

    #endregion

    #region Unity�ص�����

    private void Start()
    {
        // ��ʼ��Image
        waitingImage = transform.Find
        	("UIWaiting/Waiting").GetComponent<Image>();
        // �������Ϊ0
        waitingImage.fillAmount = 0;
    }

    private void Update()
    {
        // ʵʱ�������߼��
        CastRay();
        // �����������ֱ�ӷ���
        if (isHovered)
        {
            return;
        }

        // ���û�б�������������Image�е���ȦͼƬ����
        waitingImage.gameObject.SetActive(false);
        // ��⵽�����岻Ϊ�յĻ�
        if (selectComponent != null)
        {
            // ��¼�����߼�⵽Ŀǰλ�õ�ʱ��
            float selectTime = Time.time - enterTime;
            if (selectTime <= selectComponent.waitingTime)
            {
                // �Ƚ���ȦͼƬ��ʾ����
                waitingImage.gameObject.SetActive(true);
                waitingImage.fillAmount =
                	 selectTime / selectComponent.waitingTime;
            }
            else
            {
                // ���ʱ�����selectComponent.waitingTime
                // ��ʼִ����ѡ�ж�Ӧ�ķ���
                isHovered = true;
                selectComponent.ResponEvent(hitInfoName, hitInfoTrans);
            }
        }
    }

    #endregion

    #region ����

    /// <summary>
    /// ���߼��
    /// </summary>
    void CastRay()
    {
        // ����Ŀǰ��⵽������Ϊ��
        VRComponent currentComponent = null;

        // �������߷���ķ���
        Vector3 rayDirection = transform.forward;

        // ����������壬������ײ��Ϣ
        if (Physics.Raycast(transform.position, 
        	rayDirection, out hitInfo, float.MaxValue))
        {
            currentComponent =
            	 hitInfo.collider.GetComponent<VRComponent>();
            // �������߼�⵽����������ֺ�Transform
            hitInfoName = hitInfo.collider.name;
            hitInfoTrans = hitInfo.collider.transform;
        }

        // ���ѡ���е����岻�ǵ�ǰ��⵽������
        if (currentComponent != selectComponent)
        {
            // ˵��û�б�����
            isHovered = false;
            selectComponent = currentComponent;
            // ��¼��ǰʱ��
            enterTime = Time.time;
        }
    }

    #endregion
}