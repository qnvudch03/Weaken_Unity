using Unity.Netcode;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    public Vector2 direction; // 이동 방향
    private const float BallSpeed = 10f; // 최초 이동 속도
    private float currentSpeed = BallSpeed; // 현재 속도
    
    // 최초 공의 방향을 결정
    public override void OnNetworkSpawn()
    {
        Debug.Log("Spawn" + transform.position);

        //GameManager.Instance.InitBallServerRpc(this);
        //GetComponent<PositionSync>().InitBallServerRpc();
    }

    //public void Setdirection(Vector2 Directon)
    //{
    //    direction = Directon;
    //}

    //public void SetPosition(Vector2 pos)
    //{
    //    transform.position = pos;
    //}

    private void FixedUpdate()
    {

        Debug.Log("Update" + transform.position);

        if(transform.position.x ==0 || transform.position.y == 0)
        {
             int aplle = 10;
        }

        // 서버가 아니거나 게임이 종료된 경우 이동 처리를 하지 않음
        if (!IsServer || !GameManager.Instance.IsGameActive)
        {
            return;
        }

        // 공의 이동 거리를 계산
        var distance = currentSpeed * Time.deltaTime;

        // 공의 이동 방향으로 레이캐스트를 통해 충돌 검사
        var hit = Physics2D.Raycast(transform.position, direction, distance);

        // 무언가와 충돌하지 않은 경우
        if (hit.collider == null)
        {
            // 위치 이동 적용
            transform.position += (Vector3)(direction * distance);
        }
        else if (hit.collider.CompareTag("Player"))
        {
            // 충돌한 게임 오브젝트가 스코어 존인 경우
            if (hit.point.x < 0f)
            {
                // 왼쪽 스코어 존인 경우 플레이어 1번에 점수 추가
                //GameManager.Instance.AddScore(1, 1);
                GameManager.Instance.DecreasePlayerLifePoint(0, 1);
            }
            else
            {
                // 오른쪽 스코어 존인 경우 플레이어 0번에 점수 추가
                //GameManager.Instance.AddScore(0, 1);
                GameManager.Instance.DecreasePlayerLifePoint(1, 1);

            }

            Destroy(gameObject);
        }
        else // 무언가와 충돌했지만 스코어링 존에 충돌하지 않은 경우
        {
            Destroy(gameObject);
        }
    }
}