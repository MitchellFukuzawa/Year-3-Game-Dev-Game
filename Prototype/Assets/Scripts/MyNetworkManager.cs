using UnityEngine;
using UnityEngine.Networking;
public class MyNetworkManager : NetworkManager
{
    private int i = 1;
    public Transform pos1;
    public Transform pos2;


    public override void OnClientConnect(NetworkConnection conn) {
         ClientScene.AddPlayer(conn, 0);
     }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {

        print("<color=lime><b><i>Spawning...</i></b></color>");
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        switch (i)
        {
            case 1:
                player.transform.position = pos1.position;
                print("<color=orange>Spawning @Pos1</color>");
                break;
            case 2:
                player.transform.position = pos2.position;
                print("<color=orange>Spawning @Pos2</color>");
                break;
        }
        
        //player.GetComponent<Player>().color = Color.red;
        //print("Spawn Object Name:" + player.name);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        player.name = player.name + i;
        

        var playerScriptPlayer = player.GetComponent<Player_Networking>();
        playerScriptPlayer.H_LS_PNum = "H_LStick" + i.ToString();
        playerScriptPlayer.V_LS_PNum = "V_LStick" + i.ToString();
        playerScriptPlayer.H_RS_PNum = "H_RStick" + i.ToString();
        playerScriptPlayer.V_RS_PNum = "V_RStick" + i.ToString();

        print("<color=lime>PlayerSciptPlayer: " + playerScriptPlayer.H_LS_PNum + "</color>");

        var playerChildGunBehavior = player.transform.GetChild(1).GetComponent<GunBehavior>();
        playerChildGunBehavior.RT_PNum = "RT" + i.ToString();
        playerChildGunBehavior.xButton_PNum = "XButton" + i.ToString();
        player.SetActive(true);
        print("<color=red>i:" + i + "</color>");
        i++;
    }
}