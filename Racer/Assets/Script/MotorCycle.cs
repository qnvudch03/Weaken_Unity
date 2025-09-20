using UnityEngine;

public class MotorCycle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int id { get; private set; }
    public MOTORCYCLESTATE state { get; private set; }

    public void CollideWithMotorCycle()
    {

    }

    public void CollideWithCollection()
    {

    }

    public void CollideWithRazer()
    {

    }

    public void CollideWithTrackBarrier()
    {

    }

    public void CollideWithRoadBlock()
    {

    }

    void Start()
    {
        GameManager gameManager = GameManager.GetInstance();


        gameManager.RegisteBikeColide(id, COLLISIONTYPE.MOTORCYCLE ,this.CollideWithMotorCycle);
        gameManager.RegisteBikeColide(id, COLLISIONTYPE.COLLECTION, this.CollideWithCollection);
        gameManager.RegisteBikeColide(id, COLLISIONTYPE.RAZER, this.CollideWithRazer);
        gameManager.RegisteBikeColide(id, COLLISIONTYPE.TRACKBARRIER, this.CollideWithTrackBarrier);
        gameManager.RegisteBikeColide(id, COLLISIONTYPE.ROADBLOCK, this.CollideWithRoadBlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
