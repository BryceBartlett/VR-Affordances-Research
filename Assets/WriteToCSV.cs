using System.Collections;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Globalization;

public class WriteToCSV : MonoBehaviour
{
    void Update()
    {
        // Record all the info in a CSV and then reset the entire sim
        if (Input.GetKeyDown(KeyCode.R))
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\SubjectNumber_" + PlayerInfo.Subject + "_Test.csv";
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
            {
                writer.WriteLine("Subject:," + PlayerInfo.Subject);
                writer.WriteLine("Age:," + PlayerInfo.Age);
                writer.WriteLine("Hand:," + PlayerInfo.Hand);
                writer.WriteLine("Gender:," + PlayerInfo.Gender);
                writer.WriteLine("Date:," + "\"" + DateTime.Now + "\"");
                writer.WriteLine("Response,Cube Size,Position,Reaction");
                ArrayList cubes_and_reactions = PlayerInfo.Cubes_Reactions;
                ArrayList cubes_and_reactions_2m = PlayerInfo.Cubes_Reactions_2m;
                for (int count = 0; count < cubes_and_reactions.Count; count++)
                {
                    String result_line =  (String)cubes_and_reactions[count];
                    writer.WriteLine(result_line);
                }
                writer.WriteLine("2M Tests");
                writer.WriteLine("Response,Position,Reaction");
                for (int count = 0; count < cubes_and_reactions_2m.Count; count++)
                {
                    String result_line = (String)cubes_and_reactions_2m[count];
                    writer.WriteLine(result_line);
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
