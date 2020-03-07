using System;
using System.Collections;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using TMPro;

public class Answer : MonoBehaviour
{
    public SteamVR_Action_Boolean answer;
    public TextMeshProUGUI text;
    public Hand hand;
    GameObject six;
    GameObject seven;
    GameObject eight;
    GameObject nine;
    GameObject ten;
    GameObject eleven;
    GameObject twelve;
    GameObject thirteen;
    GameObject fourteen;
    GameObject fifteen;
    GameObject sixteen;
    GameObject seventeen;
    GameObject eighteen;
    GameObject nineteen;
    GameObject twenty;
    GameObject twenty_one;
    GameObject twenty_two;
    GameObject red8;
    GameObject blue8;
    System.Random random;
    bool first_cube_placed;
    bool first_cube_placed_2m;
    bool two_cm_mode;
    bool tutorial_2cm;
    bool tutorial_cube;
    GameObject last_cube;
    ArrayList cube_positions;
    ArrayList increments;
    ArrayList cubes;
    bool wait_a_frame;
    bool flip_flop;
    float reaction_time;
    float start_time;
    int tutorial_cube_stage;
    int tutorial_cube_stage_2m;

    void Start()
    {
        six = GameObject.Find("6");
        seven = GameObject.Find("7");
        eight = GameObject.Find("8");
        nine = GameObject.Find("9");
        ten = GameObject.Find("10");
        eleven = GameObject.Find("11");
        twelve = GameObject.Find("12");
        thirteen = GameObject.Find("13");
        fourteen = GameObject.Find("14");
        fifteen = GameObject.Find("15");
        sixteen = GameObject.Find("16");
        seventeen = GameObject.Find("17");
        eighteen = GameObject.Find("18");
        nineteen = GameObject.Find("19");
        twenty = GameObject.Find("20");
        twenty_one = GameObject.Find("21");
        twenty_two = GameObject.Find("22");
        red8 = GameObject.Find("red8");
        blue8 = GameObject.Find("blue8");
        cubes = new ArrayList
        {
            six,
            seven,
            eight,
            nine,
            ten,
            eleven,
            twelve,
            thirteen,
            fourteen,
            fifteen,
            sixteen,
            seventeen,
            eighteen,
            nineteen,
            twenty,
            twenty_one,
            twenty_two
        };
        random = new System.Random();
        first_cube_placed = false;
        first_cube_placed_2m = false;
        two_cm_mode = false;
        wait_a_frame = false;
        flip_flop = false;
        tutorial_2cm = false;
        tutorial_cube = false;
        increments = new ArrayList();
        Int32.TryParse(PlayerInfo.Subject, out int result);
        cube_positions = new ArrayList();
        // Choose what test is first based off of Subject # value
        if (result % 2 != 0)
        {
            two_cm_mode = true;
            tutorial_2cm = false;
            tutorial_cube = true;
            text.text = "Practice Trial Reaching";
        }
        else
        {
            // Wait till the end of the regular mode to start the 2cm tutorial
            text.text = "Practice Trial Grasping";
            tutorial_2cm = true;
        }
        for (float i = .0f; i <= .8; i += .02f)
        {
            increments.Add(i);
            increments.Add(i);
        }
        foreach (GameObject cube in cubes) 
        {
            Tuple<GameObject, int> cube_40 = new Tuple<GameObject, int>(cube, 40);
            Tuple<GameObject, int> cube_60 = new Tuple<GameObject, int>(cube, 60);
            cube_positions.Add(cube_40);
            cube_positions.Add(cube_60);
        }
        tutorial_cube_stage = 0;
        tutorial_cube_stage_2m = 0;
    }

    void Update()
    {
        // Tutorial before actual test
        if (!tutorial_cube)
        {
            text.text = "Practice Trial Grasping";
            if ((SteamVR_Actions.psych_Yes.lastStateDown || Input.GetKeyDown(KeyCode.Y)) || (SteamVR_Actions.psych_No.lastStateDown || Input.GetKeyDown(KeyCode.N)))
            {
                if (tutorial_cube_stage == 2)
                {
                    GameObject camera = GameObject.Find("Player Controller");
                    Vector3 old_pos = camera.transform.position;
                    camera.transform.position = new Vector3(20, 20, 20);
                    six.transform.position = new Vector3(5f, 5f, 5f);
                    twenty_two.transform.eulerAngles = new Vector3(0, 45, 0);
                    twenty_two.transform.position = new Vector3(-0.771f, 1.0f, 0.1f);
                    StartCoroutine(Wait_for_two(camera, old_pos));
                }
                if (tutorial_cube_stage == 1)
                {
                    GameObject camera = GameObject.Find("Player Controller");
                    Vector3 old_pos = camera.transform.position;
                    camera.transform.position = new Vector3(20, 20, 20);
                    six.transform.eulerAngles = new Vector3(0, 45, 0);
                    six.transform.position = new Vector3(-0.971f, 1.0f, 0.1f);
                    StartCoroutine(Wait_for_two(camera, old_pos));
                }
                if (tutorial_cube_stage == 0)
                {
                    // 6cm at 40
                    GameObject camera = GameObject.Find("Player Controller");
                    Vector3 old_pos = camera.transform.position;
                    camera.transform.position = new Vector3(20, 20, 20);
                    six.transform.eulerAngles = new Vector3(0, 45, 0);
                    six.transform.position = new Vector3(-0.771f, 1.0f, 0.1f);
                    StartCoroutine(Wait_for_two(camera, old_pos));
                }
                tutorial_cube_stage++;
                if (tutorial_cube_stage == 4)
                {
                    // Tutorial complete
                    tutorial_cube = true;
                    twenty_two.transform.position = new Vector3(5f,5f,5f);
                }
            }
        }

        if (!tutorial_2cm && two_cm_mode)
        {
            if ((SteamVR_Actions.psych_Yes.lastStateDown || Input.GetKeyDown(KeyCode.Y)) || (SteamVR_Actions.psych_No.lastStateDown || Input.GetKeyDown(KeyCode.N)))
            {
                text.text = "Practice Trial Reaching";
                if (tutorial_cube_stage_2m == 2)
                {
                    // 90
                    GameObject camera = GameObject.Find("Player Controller");
                    Vector3 old_pos = camera.transform.position;
                    camera.transform.position = new Vector3(20, 20, 20);
                    red8.transform.eulerAngles = new Vector3(0, 45, 0);
                    red8.transform.position = new Vector3(-1.271f, 1.0f, 0.1f);
                    StartCoroutine(Wait_for_two(camera, old_pos));
                }
                if (tutorial_cube_stage_2m == 1)
                {
                    // 10
                    GameObject camera = GameObject.Find("Player Controller");
                    Vector3 old_pos = camera.transform.position;
                    camera.transform.position = new Vector3(20, 20, 20);
                    red8.transform.eulerAngles = new Vector3(0, 45, 0);
                    red8.transform.position = new Vector3(-0.4694f, 1.0f, 0.1f);
                    StartCoroutine(Wait_for_two(camera, old_pos));
                }
                if (tutorial_cube_stage_2m == 0)
                {
                    // 70
                    GameObject camera = GameObject.Find("Player Controller");
                    Vector3 old_pos = camera.transform.position;
                    camera.transform.position = new Vector3(20, 20, 20);
                    red8.transform.eulerAngles = new Vector3(0, 45, 0);
                    red8.transform.position = new Vector3(-1.071f, 1.0f, 0.1f);
                    StartCoroutine(Wait_for_two(camera, old_pos));
                }
                tutorial_cube_stage_2m++;
                if (tutorial_cube_stage_2m == 4)
                {
                    // Tutorial complete
                    tutorial_2cm = true;
                    red8.transform.position = new Vector3(5f, 5f, 5f);
                }
            }
        }

        if ((SteamVR_Actions.psych_Yes.lastStateDown || Input.GetKeyDown(KeyCode.Y)) && !two_cm_mode && tutorial_cube)
        {
            text.text = "Grasping " + cube_positions.Count + " Trials Remaining";
            GameObject camera = GameObject.Find("Player Controller");
            Vector3 old_pos = camera.transform.position;
            camera.transform.position = new Vector3(20, 20, 20);
            Place_Block("Yes");
            StartCoroutine(Wait_for_two(camera, old_pos));
            start_time = Time.time;
        }

        if ((SteamVR_Actions.psych_No.lastStateDown || Input.GetKeyDown(KeyCode.N)) && !two_cm_mode && tutorial_cube)
        {
            text.text = "Grasping " + cube_positions.Count + " Trials Remaining";
            GameObject camera = GameObject.Find("Player Controller");
            Vector3 old_pos = camera.transform.position;
            camera.transform.position = new Vector3(20, 20, 20);
            Place_Block("No");
            StartCoroutine(Wait_for_two(camera, old_pos));
            start_time = Time.time;
        }

        if (two_cm_mode && !wait_a_frame && tutorial_2cm)
        {
            if ((SteamVR_Actions.psych_Yes.lastStateDown || Input.GetKeyDown(KeyCode.Y)))
            {
                text.text = "Reaching " + increments.Count + " Trials Remaining";
                GameObject camera = GameObject.Find("Player Controller");
                Vector3 old_pos = camera.transform.position;
                camera.transform.position = new Vector3(20, 20, 20);
                Place2M("Yes");
                StartCoroutine(Wait_for_two(camera, old_pos));
                start_time = Time.time;
            }
            if ((SteamVR_Actions.psych_No.lastStateDown || Input.GetKeyDown(KeyCode.N)))
            {
                text.text = "Reaching " + increments.Count + " Trials Remaining";
                GameObject camera = GameObject.Find("Player Controller");
                Vector3 old_pos = camera.transform.position;
                camera.transform.position = new Vector3(20, 20, 20);
                Place2M("No");
                StartCoroutine(Wait_for_two(camera, old_pos));
                start_time = Time.time;
            }
        }
        wait_a_frame = false;
    }

    private void Place_Block(String response) 
    {
        reaction_time = Time.time - start_time;
        ArrayList reactions = PlayerInfo.Cubes_Reactions;
        if (cube_positions.Count == 0) 
        {
            last_cube.transform.position = new Vector3(5, 5, 5);
            two_cm_mode = true;
            wait_a_frame = true;
            // Now make them take the 2cm tutorial
            tutorial_2cm = false;
            return;
        }
        if (first_cube_placed)
        {
            last_cube.transform.position = new Vector3(5, 5, 5);
        }
        int choice = random.Next(cube_positions.Count);
        Tuple<GameObject, int> cube_choice = (Tuple<GameObject, int>)cube_positions[choice];
        cube_positions.RemoveAt(choice);
        if (cube_choice.Item2 == 40)
        {
            cube_choice.Item1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            cube_choice.Item1.transform.eulerAngles = new Vector3(0, 45, 0);
            cube_choice.Item1.transform.position = new Vector3(-0.771f, 1.0f, 0.1f);
            last_cube = cube_choice.Item1;
            first_cube_placed = true;
            reactions.Add(response + "," + cube_choice.Item1.name + ",40," + reaction_time);
        }
        else 
        {
            cube_choice.Item1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            cube_choice.Item1.transform.eulerAngles = new Vector3(0, 45, 0);
            cube_choice.Item1.transform.position = new Vector3(-0.971f, 1.0f, 0.1f);
            last_cube = cube_choice.Item1;
            first_cube_placed = true;
            reactions.Add(response + "," + cube_choice.Item1.name + ",60," + reaction_time);
        }
    }

    private void Place2M(String response)
    {
        reaction_time = Time.time - start_time;
        if (first_cube_placed_2m) 
        {
            last_cube.transform.position = new Vector3(5f, 5f, 5f);
        }
        ArrayList reactions = PlayerInfo.Cubes_Reactions_2m;
        if (increments.Count == 0) 
        {
            red8.transform.position = new Vector3(5, 5, 5);
            blue8.transform.position = new Vector3(5, 5, 5);
            two_cm_mode = false;
            // Make them go through the regular tutorial now that 2cm is done
            tutorial_cube = false;
            return;
        }
        int choice = random.Next(increments.Count);
        float position = (float)increments[choice];
        increments.RemoveAt(choice);
        if (flip_flop)
        {
            first_cube_placed_2m = true;
            last_cube = red8;
            red8.transform.eulerAngles = new Vector3(0, 45, 0);
            red8.transform.position = new Vector3(-0.4694f - position, 1.0f, 0.095f);
            flip_flop = false;
        }
        else 
        {
            first_cube_placed_2m = true;
            last_cube = blue8;
            blue8.transform.eulerAngles = new Vector3(0, 45, 0);
            blue8.transform.position = new Vector3(-0.4694f - position, 1.0f, 0.095f);
            flip_flop = true;
        }
        float human_readable_pos = (position * 100) + 10;
        double r = Math.Round((double)human_readable_pos, 0);
        reactions.Add(response + "," + r + "," + reaction_time);
    }

    private IEnumerator Wait_for_two(GameObject camera, Vector3 old_pos) 
    {
        yield return new WaitForSeconds(2);
        camera.transform.position = old_pos;
    }
}