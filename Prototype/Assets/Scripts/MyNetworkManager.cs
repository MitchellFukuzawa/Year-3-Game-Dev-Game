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

        print("Spawning...");
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        switch (i)
        {
            case 1:
                player.transform.position = pos1.position;
                print("Spawning Pos1");
                break;
            case 2:
                player.transform.position = pos2.position;
                print("Spawning Pos2");
                break;
        }
        //player.GetComponent<Player>().color = Color.red;
        print("Spawn Object Name:" + player.name);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        player.name = player.name + i;
        player.GetComponent<Player>().H_LS_PNum = "H_LStick" + i.ToString();
        player.GetComponent<Player>().V_LS_PNum = "V_LStick" + i.ToString();
        player.GetComponent<Player>().H_RS_PNum = "H_RStick" + i.ToString();
        player.GetComponent<Player>().V_RS_PNum = "V_RStick" + i.ToString();
        player.transform.GetChild(1).GetComponent<GunBehavior>().RT_PNum = "RT" + i.ToString();
        player.transform.GetChild(1).GetComponent<GunBehavior>().xButton_PNum = "XButton" + i.ToString();


        i++;
    }
}