using Unity.Netcode;
using UnityEngine;

// 플레이어로서 공을 받아내는 패들(판때기) 구현
public class PlayerPaddle : NetworkBehaviour
{
    // 패들 색상을 변경하기 위한 컴포넌트
    private SpriteRenderer _spriteRenderer;
    public float speed = 10f; // 이동 속도

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 패들 색상을 변경
    [ClientRpc]
    public void SetRendererColorClientRpc(Color color)
    {
        _spriteRenderer.color = color;
    }

    [ClientRpc]
    public void SetPlayerReverseClientRpc(bool flip)
    {
        _spriteRenderer.flipX = true;
        Vector3 firePos = transform.Find("FirePosition").localPosition;
        firePos.x *= -1;

        transform.Find("FirePosition").localPosition = firePos;
    }


    // 패들 위치를 변경
    [ClientRpc]
    public void SpawnToPositionClientRpc(Vector3 position)
    {
        transform.position = position;
    }

    private void Update()
    {
        // 게임이 활성화 안된 상태에서는 이동 처리를 하지 않음
        if (GameManager.Instance != null 
            && !GameManager.Instance.IsGameActive)
        {
            return;
        }
        
        // 소유권을 가진 경우에만 이동 처리
        if (!IsOwner)
        {
            return;
        }
        
        // 키보드 입력을 받아 이동
        var input = Input.GetAxis("Vertical");
        var input_Y = Input.GetAxis("Horizontal");

        // 이동 거리를 계산하여 Y 위치를 변경
        var distance = input * speed * Time.deltaTime;
        var position = transform.position;
        Vector3 rot = transform.eulerAngles;

        float rotateAmount = 90.0f * Time.deltaTime * input_Y;
        position.y += distance;
        rot.z -= rotateAmount;

        // 이동 범위를 제한
        position.y = Mathf.Clamp(position.y, -4.5f, 4.5f);
        transform.position = position;
        transform.rotation = Quaternion.Euler(rot);

        if (GameManager.Instance != null && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 GunFirePos = transform.Find("FirePosition").position;
            Vector2 DirectVec = new Vector2(GunFirePos.x - position.x, GunFirePos.y - position.y);
            GameManager.Instance.CalledBulletServerRpc(GunFirePos, DirectVec);
        }

        //if (GameManager.Instance != null && Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rot.z += 90f * Time.deltaTime;
        //}

        //if (GameManager.Instance != null && Input.GetKey(KeyCode.RightArrow))
        //{
        //    rot.z -= 90f * Time.deltaTime;
        //}

    }
}
