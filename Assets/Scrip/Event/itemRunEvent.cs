
using System.Collections;
using UnityEngine;

public class itemRunEvent : MonoBehaviour
{

    [SerializeField]
    Transform[] position;
    [SerializeField] private int moveSpeed;
    Transform nextPosition;
    int nextIndex;

    [SerializeField] private GameObject item;
    
    

    public void Start()
    {
        onStartPosition();
             
    }

    public void Update()
    {
       OnSpawn();
    }
    public void OnSpawn()
    {
        StartCoroutine(Spawndelay());
       
    }
    private IEnumerator Spawndelay()
    {

        yield return new WaitForSeconds(2);
        item.SetActive(true);
        moveItem();


    }   
 
  


    private void onStartPosition()
    {
        nextPosition = position[0];
    }
    private void moveItem()
    {
        if(transform.position == nextPosition.position)
        {
            nextIndex++;
            if(nextIndex >= position.Length)
            {
                nextIndex = 0;
            }
            nextPosition = position[nextIndex];

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,nextPosition.position,moveSpeed *Time.deltaTime);
        }
    }
}
