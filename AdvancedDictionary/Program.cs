namespace AdvancedDictionary;

internal class Program
{
    static void Main( string[] args )
    {
        DictionaryManager m = new( "db.txt" );

        while ( true )
        {
            Console.WriteLine();
            string txt = Console.ReadLine();
            var words = m.Get( txt );
            foreach ( var word in words )
            {
                Console.WriteLine( word );
            }
        }
    }
}
