using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
	public bool alive = false;
	public bool nextAlive;
	bool prevAlive;
	public int x = -1;
	public int y = -1;
    public float growRate = 1f;
    GameManager gm;

	Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
		prevAlive = alive;

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (prevAlive != alive) {
            updateColor();
            GrowCell();
		}

		prevAlive = alive;
	}

	public void updateColor()
	{
		if (renderer == null) {
			renderer = gameObject.GetComponent<Renderer>();
		}

        Material mat = renderer.material;
        
		if (this.alive)
        { 
            mat.color = Color.green;

            // Color Code Tries Pt. 1 XD
            //renderer.material.SetColor("_EmissionColor", Color.green);
            //renderer.material.SetColor("_EmissionColor", new Color(0f, 0.5f, 0f)); // Light green 
            //renderer.material.color = Color.green;
            //renderer.material.SetColor("_Color", new Color(0f, .5f, 0f, .0f)); //darkGreen; Goes off (1f, 0f, 0f) = bright/default red
        }
        else
        {
            mat.color = Color.red;
            
            // Color Code Tries Pt. 2 XD
            //mat.SetColor("_EmissionColor", Color.red);
            //renderer.material.SetColor("_EmissionColor", Color.red);
            //renderer.material.SetColor("_EmissionColor", new Color(.5f, 0f, 0f)); // Light red
            //renderer.material.color = Color.red;
            //renderer.material.SetColor("_Color", new Color(.5f, 0f, 0f, .0f)); //darkRed; 
        }
	}

    public void GrowCell()
    {
        if (gm.simulate == true)
        {
            if (this.alive)
            {
                transform.localScale += new Vector3(0, growRate, 0);
            }
        }
        //var GameM = GameObject.Find("GameManager");
        //GameM.GetComponent(GameManager);
        
    }

	private void OnMouseDown()
	{
		alive = !alive;
	}
}
// ASSIGN FORCE TO LAUNCH DIRECTLY UP