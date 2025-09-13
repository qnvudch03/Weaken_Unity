using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    // 싱글톤 구현
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private static GameManager instance;

    // 게임이 진행 중인지 여부
    public bool IsGameActive { get; private set; }

    // 점수 표시할 UI 텍스트
    public Text scoreText;

    // 플레이어 색상, 스폰 위치
    public Color[] playerColors = new Color[2];
    public Transform[] spawnPositionTransforms = new Transform[2];
    public bool[] playerFlip = new bool[2];

    // 공 프리팹
    public GameObject ballPrefab;

    // 게임 오버 텍스트와 게임 오버시 표시할 패널
    public Text gameoverText;
    public GameObject gameoverPanel;

    // 플레이어 번호와 클라이언트 ID를 맵핑하는 딕셔너리
    private Dictionary<int, ulong> playerNumberClientIdMap
        = new Dictionary<int, ulong>();

    // 플레이어 점수를 저장하는 배열
    //private int[] playerScores = new int[2];
    private int[] playerLifePoint = new int[2];

    // 승리 도달 점수
    private const int WinScore = 11;

    // 처음 활성화시 게임을 시작하는 처리를 실행
    public override void OnNetworkSpawn()
    {
        // 서버에서만 플레이어와 공을 스폰
        if (IsServer)
        {
            SpawnPlayer();
        }

        // 게임 활성화
        IsGameActive = true;

        // 게임 오버 패널 비활성화
        gameoverPanel.SetActive(false);

        // 클라이언트가 접속하거나 떠났을 때 호출할 콜백 등록
        NetworkManager.OnClientDisconnectCallback += OnClientDisconnected;
    }

    public override void OnNetworkDespawn()
    {
        // 클라이언트가 접속하거나 떠났을 때 호출할 콜백 해제
        NetworkManager.OnClientDisconnectCallback -= OnClientDisconnected;
    }

    [ServerRpc(RequireOwnership = false)]
    public void CalledBulletServerRpc(Vector2 pos, Vector2 direction)
    {
        GameObject ballGameObject = Instantiate(ballPrefab, pos, Quaternion.identity);
        Ball ball = ballGameObject.GetComponent<Ball>();

        if (ball == null)
            return;

        ball.direction = direction;
        ball.NetworkObject.Spawn();
    }

    // 게임 도중 클라이언트가 나갔을때 실행
    private void OnClientDisconnected(ulong clinetId)
    {
        // 게임 도중에 플레이어 중 한명이 나갔다면
        // 게임을 종료하고 메뉴 화면으로 돌아감
        if (IsGameActive)
        {
            ExitGame();
        }
    }

    // 플레이어들을 스폰
    private void SpawnPlayer()
    {
        // 플레이어가 2명이 아니라면 에러를 출력하고 종료
        if (NetworkManager.ConnectedClientsList.Count != 2)
        {
            Debug.LogError("Pong can only be played by 2 players...");
            return;
        }

        // 플레이어 프리팹을 가져옴
        var playerPrefab = NetworkManager.NetworkConfig.PlayerPrefab;

        // 두명의 플레이어를 스폰
        for (var i = 0; i < 2; i++)
        {
            var client = NetworkManager.ConnectedClientsList[i];

            // 각 클라이언트 ID에 해당 클라이언트가 몇 번째 플레이어인지를 맵핑하여 저장
            playerNumberClientIdMap[i] = client.ClientId;

            // 플레이어의 스폰 위치와 색상을 가져옴
            var spawnPosition = spawnPositionTransforms[i].position;
            var playerColor = playerColors[i];

            // 플레이어 프리팹을 인스턴스화하고 네트워크 스폰
            var playerGameObject = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
            var playerPaddle = playerGameObject.GetComponent<PlayerPaddle>();
            playerPaddle.NetworkObject.SpawnAsPlayerObject(client.ClientId);

            // 플레이어의 스폰 위치와 색상을 클라이언트에게 전달
            playerPaddle.SpawnToPositionClientRpc(spawnPosition);
            playerPaddle.SetRendererColorClientRpc(playerColor);

            if (i == 1)
            {
                playerPaddle.SetPlayerReverseClientRpc(true);
            }

        }

        SetPlayerLifePoint(5);
    }

    // 공 생성
    //public void SpawnBall(Vector2 pos, Vector2 direction)
    //{
    //    // 공 프리팹을 인스턴스화하고 네트워크 스폰


    //    var ballGameObject = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
    //    var ball = ballGameObject.GetComponent<Ball>();
    //    ball.Setdirection(direction);
    //    ball.SetPosition(pos);
    //    ball.NetworkObject.Spawn();

    //}

    public void DecreasePlayerLifePoint(int playerNumber, int damage)
    {
        playerLifePoint[playerNumber] -= damage;

        UpdateScoreTextClientRpc(playerLifePoint[0], playerLifePoint[1]);

        if (playerLifePoint[playerNumber] <= 0)
        {
            int winner = (playerNumber == 0) ? 1 : 0;

            var winnerId = playerNumberClientIdMap[winner];

            EndGame(winnerId);
        }
    }

    // 점수 텍스트 갱신
    [ClientRpc]
    private void UpdateScoreTextClientRpc(int player0Score, int player1Score)
    {
        scoreText.text = $"{player0Score} : {player1Score}";
    }

    // 서버에서 실행할 게임 종료
    public void EndGame(ulong winnerId)
    {
        // 서버에서만 실행 가능
        if (!IsServer)
        {
            return;
        }

        // 공을 스폰해제
        var ball = FindObjectOfType<Ball>();
        ball.NetworkObject.Despawn();

        // 게임 오버 처리를 클라이언트들에게 전파
        EndGameClientRpc(winnerId);
    }

    // 클라이언트에서 실행할 게임 종료 처리
    [ClientRpc]
    public void EndGameClientRpc(ulong winnerId)
    {
        // 게임 오버 처리
        IsGameActive = false;

        // 입력으로 전달된 승자가 자신인 경우
        if (winnerId == NetworkManager.LocalClientId)
        {
            gameoverText.text = "You Win!";
        }
        else // 입력으로 전달된 승자가 자신이 아닌 경우
        {
            gameoverText.text = "You Lose!";
        }

        // 게임 오버 패널 활성화
        gameoverPanel.SetActive(true);
    }

    //[ServerRpc(RequireOwnership = false)]
    //public void InitBallServerRpc(Ball ball)
    //{
    //    PositionSync sync = ball.GetComponent<PositionSync>();

    //    sync.networkPosition.Value = ball.transform.position;
    //    sync.networkRotation.Value = ball.transform.rotation;

    //}

    // 게임과 네트워크 연결을 종료하고 메뉴 화면으로 돌아감
    public void ExitGame()
    {
        NetworkManager.Singleton.Shutdown();
        SceneManager.LoadScene("Menu");
    }

    void SetPlayerLifePoint(int life)
    {
        playerLifePoint[0] = life;
        playerLifePoint[1] = life;

        UpdateScoreTextClientRpc(playerLifePoint[0], playerLifePoint[1]);
    }
}