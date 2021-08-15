using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool shooterscene;
    public float time;
    public Text Timed;
    public Lookattake Scores;
    public Transform itstime;
    public Text Bestscore;
    public Text Currentscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shooterscene == true)
        {
            time += 1f * Time.deltaTime;
            Timed.text = time.ToString();
        }
        if(time >= 300f)
        {
            float Bestscores = PlayerPrefs.GetFloat("Score");
            itstime.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if(Scores.soylentbottles >= Bestscores)
            {
                Bestscores = Scores.soylentbottles;
                PlayerPrefs.SetFloat("Score", Scores.soylentbottles);
                PlayerPrefs.Save();
            }
            Bestscore.text = Bestscores.ToString();
            Currentscore.text = Scores.soylentbottles.ToString();
        }
    }
}
