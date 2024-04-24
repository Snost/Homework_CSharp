namespace HomeworkModul06;

internal class Program
{
    static void Main(string[] args)
    {
        //1
        Money money = new Money(50, 20);
        Product product = new Product(money, "Toy");
        Console.WriteLine("Product: " + product.Name);
        Console.WriteLine("Price: " + product.GetPrice());
        product.DecreaseSum(34);
        Console.WriteLine("Change price : " + product.GetPrice());
        //2

        Kettle kettle = new Kettle("Kettle", "Boiling water", "*byl byl byl*");
        kettle.Show();
        Console.WriteLine(" ");
        kettle.Desc();
        Console.WriteLine(" ");
        kettle.Sound();
        Console.WriteLine("---------------------------");
        Auto auto = new Auto("Car", "Riding", "*Bip Bip Bip*");
        auto.Show();
        Console.Write(" - ");
        auto.Desc();
        Console.Write(" - ");
        auto.Sound();
        //3

        Violin violin = new Violin("Violin", "bowed musical instrument with four strings", "truuun truuun", "The prototypes of the violin were the Arab rebab and the German company, of which several were created.");
        violin.Show();
        Console.WriteLine(" ");
        violin.Desc();
        Console.WriteLine(" ");
        violin.Sound();
        Console.WriteLine(" ");
        violin.History();
        Console.WriteLine(" ");
        Console.WriteLine("---------------------------");

        Trombone trombone = new Trombone("Trombone", "European embouchure wind instrument", "tru tru tru", "The appearance of the trombone dates back to the 15th century. It is generally accepted that the immediate predecessors of this instrument were rocker trumpets, when playing which the musician had the opportunity to move the instrument tube, thus obtaining a chromatic scale. Such trumpets were used to double the voices of a church choir, given the similarity of the timbre of the trumpet to the human voice. It was only necessary to achieve similarity in intonation, for which they made a backstage that gave chromaticism.");
        trombone.Show();
        Console.WriteLine(" ");
        trombone.Desc();
        Console.WriteLine(" ");
        trombone.Sound();
        Console.WriteLine(" ");
        trombone.History();
        Console.WriteLine(" ");
        Console.WriteLine("---------------------------");

        Ukulele ukulele = new Ukulele("Ukulele", "a four-string type of guitar used for chord accompaniment of songs and playing solos.", "trun` trun`", "Kulele appeared on the Hawaiian Islands in the second half of the 19th century, where it was brought by the Portuguese from the island of Madeira under the name masheti da brasa.");
        ukulele.Show();
        Console.WriteLine(" ");
        ukulele.Desc();
        Console.WriteLine(" ");
        ukulele.Sound();
        Console.WriteLine(" ");
        ukulele.History();
        Console.WriteLine(" ");
        Console.WriteLine("---------------------------");

        Violoncello violoncello = new Violoncello("Violoncello", "bowed musical instrument with 4 strings", "tryyyn tryyn", "The appearance of the cello dates back to the beginning of the 16th century. It was originally used as a bass instrument to accompany singing.");
        violoncello.Show();
        Console.WriteLine(" ");
        violoncello.Desc();
        Console.WriteLine(" ");
        violoncello.Sound();
        Console.WriteLine(" ");
        violoncello.History();
        Console.WriteLine(" ");
        Console.WriteLine("---------------------------");

        //4
        President president = new President("Tom", "people management");
        president.Work();

    }
}