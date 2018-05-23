public class GameBoard {

    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }

	public GameBoard(Player p1, Player p2)
    {
        Player1 = p1;
        Player2 = p2;
    }
}
