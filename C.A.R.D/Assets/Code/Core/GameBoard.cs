public class GameBoard {

    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }

    public Field Field1 { get; private set; }
    public Field Field2 { get; private set; }

    public GameBoard(Player p1, Player p2)
    {
        Player1 = p1;
        Player2 = p2;

        Field1 = new Field();
        Field2 = new Field();

		Player1.SetFields(Field1,Field2);
		Player2.SetFields(Field2,Field1);
    }
}
