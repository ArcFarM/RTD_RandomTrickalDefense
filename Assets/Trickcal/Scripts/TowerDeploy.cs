using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Placement : MonoBehaviour
{
    //��ġ ĭ ���� ���콺�� �ø��� q��ư�� ������ Ÿ�� ��ġ
    //ĭ ���� ���콺�� �ø��� w��ư�� ������ �� ĭ�� �������� ������ Ÿ���� �ϳ� �ռ��Ͽ� �� ���� ����� Ÿ���� �� �ڸ��� ������ ����
    //e��ư�� ������ ���� ���ۺ��� �ݰ��� �ְ� �Ǹ�
    //����Ÿ�� �Ǽ� ��ư�� ������ Ÿ�� ���� ����� ������, �װ� Ŭ���ϰ� ĭ�� Ŭ���ϸ� ���� Ÿ�� ��ġ
    // Start is called before the first frame update

    //Ÿ�� ��ȣ�ۿ�� ���콺 �ö� �ִ� ���� �����ϱ� ���� �÷���
    bool tower_build_flag = false;
    bool tower_upgrade_flag = false;
    bool tower_sell_flag = false;
    bool mouse_over_flag = false;
    bool is_tower_built = false;

    GameObject tower;

    // Update is called once per frame
    void Update()
    {
        //q,w,e�� ������ Ÿ�� ��ġ ����/Ÿ�� �ռ� ����/Ÿ�� �Ǹ� ���� ������ ������
        //�׸��� ������ ������ Ŭ���� �ϸ� ������ �����ϰ�, �׷��� ������ ���
        if (Input.GetKey(KeyCode.Q))
        {
            if (!is_tower_built)
            {
                //Ÿ�� ��ġ ���� ���� ������
                tower_build_flag = true;
            }
            //Ÿ���� ��ġ�� �� �ִ� ������ ���콺�� �ø��� �ְ�
            if(tower_build_flag && mouse_over_flag)
            {
                //�� �������� �ٷ� ���콺�� ������
                if (Input.GetMouseButton(0))
                {
                    //Ÿ�� �Ǽ� ����
                    //�Ǽ� ���� �� �÷��� ����
                    tower_build_flag = false;
                    is_tower_built=true;
                }

            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Ÿ���� �����ϰ�, ���� Ÿ���� �ִٸ� Ȱ��ȭ ����
            {
                //Ÿ�� �ռ� ���� ���� ������
                tower_upgrade_flag = true;
            }
            //Ÿ���� �ռ��� �� �ִ� ������ ���콺�� �ø��� �ְ�
            if (tower_upgrade_flag && mouse_over_flag)
            {
                //�� �������� �ٷ� ���콺�� ������
                if (Input.GetMouseButton(0))
                {
                    //Ÿ�� �ռ� ����
                    //�÷��� ����
                    tower_upgrade_flag=false;
                }
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (is_tower_built)
            {
                //Ÿ�� �Ǹ� ���� ���� ������
                tower_sell_flag = true;
            }
            //Ÿ���� �Ǹ��� �� �ִ� ������ ���콺�� �ø��� �ְ�
            if (tower_sell_flag && mouse_over_flag)
            {
                //�� �������� �ٷ� ���콺�� ������
                if (Input.GetMouseButton(0))
                {
                    //Ÿ�� �Ǹ� ����
                    //�÷��� ����
                    tower_sell_flag = false;
                    is_tower_built = false;
                }
            }
        }
    }

    //������Ʈ�� ���콺�� �ø��� �־�� ��ġ�� ����
    //���콺�� �ø��� �ִ� �� ���� �� �Ǵ��ϴ� �뵵
    void OnMouseOver()
    {
        mouse_over_flag = true;
    }
    private void OnMouseExit()
    {
        mouse_over_flag = false;
    }
}
