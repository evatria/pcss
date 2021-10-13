public class Host {
    public String name;
    public String ip;
    boolean isCorrect;
    int points;



//Host function
    public int chooseCorrect(int points, boolean isCorrect) {

        this.points = points;

        if (isCorrect = false) {
            points = -1*points;
        }
        return points;
    }


//Getters and Setters
    public String getIp() {
        return ip;
    }
    public void setIp(String ip) {
        this.ip = ip;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
}
