using System;
using Unity.Netcode;
using UnityEngine;

// 플레이어의 위치를 동기화하기 위한 컴포넌트
public class PositionSync : NetworkBehaviour
{
    private Vector2 _lastPosition; // 마지막으로 동기화된 위치
    private Quaternion _lastRotation;
    // 위치값 동기화를 위한 네트워크 변수
    public NetworkVariable<Quaternion> networkRotation
    = new NetworkVariable<Quaternion>(
        readPerm: NetworkVariableReadPermission.Everyone,
        writePerm: NetworkVariableWritePermission.Owner);
    public NetworkVariable<Vector2> networkPosition 
        = new NetworkVariable<Vector2>(
            readPerm: NetworkVariableReadPermission.Everyone,
            writePerm: NetworkVariableWritePermission.Owner);


    [ServerRpc(RequireOwnership = false)]
    public void InitBallServerRpc()
    {
        Ball ball = GetComponent<Ball>();
        networkPosition.Value = ball.transform.position;
        networkRotation.Value = ball.transform.rotation;

    }


    private void FixedUpdate()
    {
        if (IsOwner)
        {
            // 로컬 클라이언트가 소유자인 경우
            // 마지막으로 동기화된 위치와 현재 위치가 일정 거리 이상 차이가 나면
            if (Vector2.Distance(_lastPosition, transform.position) > 0.001f)
            {
                // 위치 동기화
                _lastPosition = (Vector2)transform.position;
                networkPosition.Value = _lastPosition;
            }

            if(Quaternion.Angle(_lastRotation, transform.rotation) > 0.01f)
            {
                _lastRotation = transform.rotation;
                networkRotation.Value = _lastRotation;
            }

        }
        else 
        {

            if(GetComponent<Ball>() != null)
            {
                Debug.LogWarning(networkPosition.Value);
            }

            transform.position = (Vector3)networkPosition.Value;
            transform.rotation = networkRotation.Value;
         
        }
    }
}