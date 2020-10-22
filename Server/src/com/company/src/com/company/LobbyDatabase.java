package src.com.company.src.com.company;

import java.util.ArrayList;
import java.util.List;

public class LobbyDatabase {

    String lobbyName;
    String host;
    List<String> players;

    LobbyDatabase (String lobbyName, String host, List<String> players) {
        this.host = host;
        this.lobbyName = lobbyName;
        this.players = players;
    }



}
