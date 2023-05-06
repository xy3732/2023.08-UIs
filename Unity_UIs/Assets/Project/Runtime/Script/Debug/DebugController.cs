using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class DebugController : MonoBehaviour
{
    bool showConsole;
    bool showHelp;
    string input;

    public static DebugCommand HELP;
    public static DebugCommand DELETE_ALL_BOX;
    public static DebugCommand DELETE_ALL_SPHERE;
    public static DebugCommand DELETE_ALL;
    public static DebugCommand MAKE_BOX;
    public static DebugCommand MAKE_SPHERE;
    public static DebugCommand<int> SET_INT;
    public static DebugCommand<int> MAKE_BOXS;
    public static DebugCommand<int> MAKE_SPHERES;
    public static DebugCommand<int, Vector3> MAKE_BOXS_WITH_TRANSFORM;
    public static DebugCommand<int, Vector3> MAKE_SPHERES_WITH_TRANSFORM;
    public List<object> commandList;

    private void Awake()
    {
        CommandListInit();
    }

    private void CommandListInit()
    {
        DELETE_ALL_BOX = new DebugCommand("Delete_All_Boxs", "Remove all Box", "Delete_All_Boxs", () =>
        {
            TestDebug.instance.DeleteAllBox();
        });

        DELETE_ALL_SPHERE = new DebugCommand("Delete_All_Spheres", "Remove all Sphere", "Delete_All_Spheres", () =>
        {
            TestDebug.instance.DeleteAllSphere();
        });

        DELETE_ALL = new DebugCommand("Delete_All","Remove all objects","Delete_All", () =>
        {
            TestDebug.instance.DeleteAll();
        });

        MAKE_BOX = new DebugCommand("Make_Box", "Make box object", "Make_Box", () =>
        {
            TestDebug.instance.AddBox();
        });

        MAKE_SPHERE = new DebugCommand("Make_Sphere", "Make sphere object", "Make_Sphere", () =>
        {
            TestDebug.instance.AddSphere();
        });

        SET_INT = new DebugCommand<int>("set_Int", "set custom int", "set_Int <Custom Int>", (x) =>
        {
            TestDebug.instance.SetInt(x);
        });

        MAKE_BOXS = new DebugCommand<int>("Make_Box_Input", "Make boxs object", "Make_Box_Input <Custom Int>", (x) =>
        {
            TestDebug.instance.AddBox(x);
        });

        MAKE_SPHERES = new DebugCommand<int>("Make_Sphere_Input", "Make spheres object", "Make_Sphere_Input <Custom Int>", (x) =>
        {
            TestDebug.instance.AddSphere(x);
        });

        MAKE_BOXS_WITH_TRANSFORM = new DebugCommand<int, Vector3>("Make_Box_Input_Trans", "Make box object with transform", "Make_Box_Input_Trans <Custom Int> <transform Vector3>", (x1, x2) =>
        {
            TestDebug.instance.AddBox(x1, x2);
        });

        MAKE_SPHERES_WITH_TRANSFORM = new DebugCommand<int, Vector3>("Make_Sphere_Input_Trans", "Make spheres object with transform", "Make_Sphere_Input_Trans <Custom Int> <transform Vector3>", (x1, x2) =>
        {
            TestDebug.instance.AddSphere(x1, x2);
        });

        HELP = new DebugCommand("Help", "show a list of command", "Help", () =>
        {
            showHelp = true;
        });

        commandList = new List<object>
        {
            HELP,
            DELETE_ALL_BOX,
            DELETE_ALL_SPHERE,
            DELETE_ALL,
            MAKE_SPHERE,
            MAKE_SPHERES,
            MAKE_BOX,
            MAKE_BOXS,
            MAKE_BOXS_WITH_TRANSFORM,
            MAKE_SPHERES_WITH_TRANSFORM,
            SET_INT,
        };

    }

    public void OnToggleDebug(InputValue value)
    {
        showConsole = !showConsole;
    }

    public void OnReturn(InputValue value)
    {
        if (showConsole)
        {
            showHelp = false;
            HandleInput();
            input = "";
        }
    }

    private void HandleInput()
    {
        string[] properties = input.Split(' ');

        for(int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (properties[0].Equals(commandBase.commandID))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
                else if(commandList[i] as DebugCommand<int> != null)
                {
                    try
                    {
                        (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {
                       
                    }
                }
                else if(commandList[i] as DebugCommand<int,Vector3> != null)
                {

                    try
                    {
                        Debug.Log(properties[2]);
                        (commandList[i] as DebugCommand<int,Vector3>).Invoke(int.Parse(properties[1]), string2Vector3(properties[2]));
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {

                    }
                }
            }
        }
    }

    public Vector3 string2Vector3(string value)
    {
        string[] temp = value.Split(",");
        return new Vector3(float.Parse(temp[0]), float.Parse(temp[1]), float.Parse(temp[2]));
    }

    Vector2 scroll;
    private void OnGUI()
    {
        if (!showConsole) return;

        float y = 0f;

        // 디버그 콘솔 백그라운드 설정
        GUI.Box(new Rect(0, y, Screen.width, 30), "");

        // 텍스트 박스
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        GUI.color = new Color32(255, 255, 255, 255);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

        if (showHelp)
        {
            y += 30f;
            GUI.backgroundColor = new Color32(75, 75, 75, 175);
            GUI.color = new Color32(255, 255, 255, 255);
            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            // 콘솔 명령어 갯수만큼 스크롤 뷰 크기 조정
            Rect viewport = new Rect(0,0,Screen.width-30, 20 * commandList.Count);
            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            // 스크롤 뷰 안에 디버그 콘솔 명령어 추가
            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;
                string label = $"{command.commandFormat} : {command.commandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100 , 20);

                GUI.Label(labelRect, label);
            }
            GUI.EndScrollView();

            y+= 100;
        }
    }
}
