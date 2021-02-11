using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace Fungus    // �÷ο���Ʈ ����� �ʿ���
{
    public class ClueManager : MonoBehaviour
    {
        // �÷ο� ��Ʈ���� �޾ƿ� ����
        public GameObject gameObject;
        public Flowchart flowChart;
        public int dayNum;
        public int clueNum;

        // �ܼ� ������, �ܼ� �������� �ʿ��� ����
        Dictionary<int, string[]> clueData = new Dictionary<int, string[]>();
        public string[] clueValue = new string[6];      // ��ųʸ��� �ִ� value �ӽ÷� ���� ����
        public string[] leftPageTxt = new string[15];   // Day�� ���� ���� ���� ����
        public string[][] rightPageTxt = new string[15][];  // �ܼ��� ���� ���� ���� ����
        public Text leftUIText; // Day�� ���� ������ ������ UI
        public Text rightUIText;    // �ܼ��� ���� ���� ������ UI
        public bool addedClue = false;  // �ܼ� �ߺ� �߰� ���� ����



        // Start is called before the first frame update
        void Start()
        {
            // ������ �ʱ�ȭ
            gameObject = GameObject.Find("Start_day1");
            flowChart = gameObject.GetComponent<Flowchart>();
            dayNum = flowChart.GetIntegerVariable("dayNum");
            clueNum = flowChart.GetIntegerVariable("clueNum");
            leftUIText = GameObject.Find("Date").GetComponent<Text>();
            rightUIText = GameObject.Find("Clues").GetComponent<Text>();
            // �ܼ� ������ ����
            GenerateData();
            //Memoing();
            //clueData.TryGetValue(dayNum, out clueValue);
            //Debug.Log(clueValue[clueNum]);
        }

        // Update is called once per frame
        void Update()
        {
            // ������ ������Ʈ
            dayNum = flowChart.GetIntegerVariable("dayNum");
            // �ܼ� �߰� ���� Ȯ��
            if (clueNum != (clueNum = flowChart.GetIntegerVariable("clueNum")))
                addedClue = false;
            // �ܼ��� �ѹ��� �߰�
            if (!addedClue)
            {
                Memoing();   // ���ƴ�..?
                addedClue = true;
            }
        }

        // ��ųʸ��� ���̺� �ܼ����� ����
        void GenerateData()
        {
            clueData.Add(1, new string[] {"�����ƿ� ���̺�� �ο�",
            "���̺��� ����ũ�� �پ�ٴ�",
            "������ - �� ���� ���̺�� - ���� ����" ,
            "���� �����Ƹ� ������",
            "���̺��� ���ڸ� �� �����Ѵ�?",
            "���� ���� �㸶�� ������ �����"
             });
            clueData.Add(2, new string[] {"������Ʈ ���� ������ �ٳన(�ֱ������� ���� ��)",
        "������Ʈ ���� �ó� �ø���� �ٳన(��� �� ���ƺ���)"
    });//2

            clueData.Add(3, new string[] {"������Ʈ�� ������ ���� ������ ������ ���� ��",
        "���� �� �ϳ��� ���� �ƹ������ٴ� ��⵵..."
    });//2

            clueData.Add(4, new string[] {"�����ƴ� ��ī�ο� ������ ���� ��� �����",
        "��Ұ��������� �������� ���� 1���̾���"
    });//2
            clueData.Add(5, new string[] { "�ܼ��� �� ������ �����ϴ�." });

            clueData.Add(6, new string[] {"����ũ�� ���̺��� ���� ����",
        "������Ʈ ������ ����",
        "�����ư� ������Ʈ���� ���� ��� �� ����� ���̺�忡�� ��"
    });//3

            clueData.Add(7, new string[] {"������ �� ī��Ʈ�� ���λ�",
        "��� ���忡�� ���̺���� �� ���� �ռ��� �߰ߵ�"
    });//2

            clueData.Add(8, new string[] { "�ܼ��� �� ������ �����ϴ�." });

            clueData.Add(9, new string[] {"�ó� �ø���ư� �����ƿ��� �ӽ��� ǰ�� �־���"
    });//1

            clueData.Add(10, new string[] {"�ø���ư� ���� �� ������ �� ���� ����Ÿ��� �� �� ����ڰ� ����",
        "�ø���� :��ġ�� �� �� ������ ���� ��� �־ �õ��� �� �غ��� ���ƿԾ��"
    });//2

            clueData.Add(11, new string[] {"���̺�� ���� ����ũ�� �����Ƹ� ������ �����ϰ�, ����� ���̺�忡�� �������� �Ѵٴ� ����"
    });//1

            clueData.Add(12, new string[] { "�ܼ��� �� ������ �����ϴ�." });

            clueData.Add(13, new string[] {"�ø���ư� �ٽ� �� �� �������� �� ���� ������� �ʾҴ�",
        "ī�꿡�� �׵��� ���� ���� ����� �־���"
    });//2

            clueData.Add(14, new string[] {"ó������ ���� ������� �ʾ��� ����..?"
    });//1

            clueData.Add(15, new string[] { "�ܼ��� �� ������ �����ϴ�." });

        }

        // UI�� ������ ������ ������ �̸� �����ϰ� �����ֱ�����ϰ� �������ȴ�..
        void Memoing()
        {
            clueData.TryGetValue(dayNum, out clueValue);
            rightUIText.text = "";
            switch (dayNum)
            {
                case 1:
                    //leftPageTxt[0] = "Day1";
                    leftUIText.text = "Day1";
                    rightPageTxt[0] = clueValue;
                    rightUIText.text += rightPageTxt[0][clueNum] + "\n";
                    break;
                case 2:
                    leftPageTxt[1] = "Day2";
                    rightPageTxt[1][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 3:
                    leftPageTxt[2] = "Day3";
                    rightPageTxt[2][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 4:
                    leftPageTxt[3] = "Day4";
                    rightPageTxt[3][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 5:
                    leftPageTxt[4] = "Day5";
                    rightPageTxt[4][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 6:
                    leftPageTxt[5] = "Day6";
                    rightPageTxt[5][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 7:
                    leftPageTxt[6] = "Day7";
                    rightPageTxt[6][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 8:
                    leftPageTxt[7] = "Day8";
                    rightPageTxt[7][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 9:
                    leftPageTxt[8] = "Day9";
                    rightPageTxt[8][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 10:
                    leftPageTxt[9] = "Day10";
                    rightPageTxt[9][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 11:
                    leftPageTxt[10] = "Day11";
                    rightPageTxt[10][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 12:
                    leftPageTxt[11] = "Day12";
                    rightPageTxt[11][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 13:
                    leftPageTxt[12] = "Day13";
                    rightPageTxt[12][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 14:
                    leftPageTxt[13] = "Day14";
                    rightPageTxt[13][clueNum] += clueValue[clueNum] + "\n";
                    break;
                case 15:
                    leftPageTxt[14] = "Day15";
                    rightPageTxt[14][clueNum] += clueValue[clueNum] + "\n";
                    break;
                default:
                    break;
            }


        }

        void ShowClueToBook()
        {
            // ���� ������ �����ֱ�
            
        
            leftUIText.text = "Day1";   // �̷����ϸ� ������������ Day1�̶�� ���ڰ� ��
            leftUIText.text = leftPageTxt[0];   // �̷����ϸ� ������������ �ƹ��͵� �ȶ�
            // �ƹ�����  Memoing()���� pass by reference�� �ƴ϶� pass by value�� �־ �׷���?

           // rightUIText.text += rightPageTxt[0][clueNum] + "\n";
            //
            // ������ ������ �����ֱ�
            //for(int i = 0; i < rightPageTxt[dayNum-1].Length; i++)
           // {
            //    rightUIText.text += rightPageTxt[dayNum - 1][i] + "\n";
            //}
        }

        
    }
    
}
