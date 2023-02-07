using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CursorBehavior : MonoBehaviour
{
    Vector2 cursorPosition;
    private bool oneIsSelected = false;
    private bool twoIsSelected = false;
    private bool threeIsSelected = false;
    private bool canPlace = false;
    private bool inBoxOne = false;
    private bool inBoxTwo = false;
    private bool inBoxThree = false;
    private float towerOnePrice = 100f;
    private float towerTwoPrice = 150;
    private float towerThreePrice = 300f;
    public float money;
    public int lives = 5;
   
    [SerializeField] GameObject turretOneIcon;
    [SerializeField] GameObject turretTwoIcon;
    [SerializeField] GameObject turretThreeIcon;
    [SerializeField] GameObject turretOne;
    [SerializeField] GameObject turretTwo;
    [SerializeField] GameObject turretThree;

    [SerializeField] AudioSource towerPlace;


    [SerializeField] Text moneyText;

    private GameObject tempIcon;
    // Start is called before the first frame update
    void Start()
    {
        money = 250;
    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(cursorPosition.x), Mathf.Round(cursorPosition.y));

        if (tempIcon != null)
        {
            tempIcon.transform.position = new Vector2(Mathf.Round(cursorPosition.x), Mathf.Round(cursorPosition.y));
        }
        

        if (oneIsSelected || twoIsSelected || threeIsSelected)
        {
            if (canPlace)
            {
                PlaceTurrent();
                
            }
            
            
        }
        if(!canPlace)
        {
            SelectTurret();
        }
        //print(inBoxTwo);
        //print(canPlace);
        //print(onPath);
        print(lives);
        moneyText.text = "Money: " + money;

        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(oneIsSelected || twoIsSelected || threeIsSelected)
        {
            canPlace = true;
        }
        inBoxOne = false;
        inBoxTwo = false;
        inBoxThree = false;


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Range")
        {
            canPlace = false;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        canPlace = false;
        if(collider.gameObject.tag == "Range")
        {
            canPlace = true;
        }
        
        
        
        if(collider.gameObject.tag == "TurretOne")
        {
            inBoxOne = true;
        }
        if (collider.gameObject.tag == "TurretTwo")
        {
            inBoxTwo = true;
            
        }
        if (collider.gameObject.tag == "TurretThree")
        {
            inBoxThree = true;

        }
       

    }

    void SelectTurret()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if(!oneIsSelected && inBoxOne)
            {
                Destroy(tempIcon);
                tempIcon = (GameObject)Instantiate(turretOneIcon,cursorPosition, Quaternion.identity);
                oneIsSelected = true;
                twoIsSelected = false;
                threeIsSelected = false;
            }
            if (!twoIsSelected && inBoxTwo)
            {
                Destroy(tempIcon);
                tempIcon = (GameObject)Instantiate(turretTwoIcon, cursorPosition, Quaternion.identity);
                twoIsSelected = true;
                oneIsSelected = false;
                threeIsSelected = false;
            }
            if (!threeIsSelected && inBoxThree)
            {
                Destroy(tempIcon);
                tempIcon = (GameObject)Instantiate(turretThreeIcon, cursorPosition, Quaternion.identity);
                threeIsSelected = true;
                oneIsSelected = false;
                twoIsSelected = false;
            }

        }
        //print("hit");
    }

    public void AddMoney()
    {
        money += 10;
        print("hit");
    }
    public void TakeDamage()
    {
        lives -= 1;
    }

    void PlaceTurrent()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (oneIsSelected && canPlace && !inBoxOne && !inBoxTwo && !inBoxThree && money >= towerOnePrice)
            {
                Instantiate(turretOne, tempIcon.transform.position, Quaternion.identity);
                Destroy(tempIcon);
                
                oneIsSelected = false;
                canPlace = false;
                money -= towerOnePrice;
                towerPlace.Play();
            }
            if (twoIsSelected && canPlace && !inBoxOne && !inBoxTwo && !inBoxThree && money >= towerTwoPrice)
            {
                Instantiate(turretTwo, tempIcon.transform.position, Quaternion.identity);
                Destroy(tempIcon);

                twoIsSelected = false;
                canPlace = false;
                money -= towerTwoPrice;
                towerPlace.Play();
            }
            if (threeIsSelected && canPlace && !inBoxOne && !inBoxTwo && !inBoxThree && money >= towerThreePrice)
            {
                Instantiate(turretThree, tempIcon.transform.position, Quaternion.identity);
                Destroy(tempIcon);

                threeIsSelected = false;
                canPlace = false;
                money -= towerThreePrice;
                towerPlace.Play();
            }
        }
        
    }
}
