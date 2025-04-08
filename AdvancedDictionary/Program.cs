namespace AdvancedDictionary;

internal class Program
{
    static void Main( string[] args )
    {
        DictionaryManager manager = new( "dictionary.txt" );
        ConsoleHelper.PrintSuccess( "Консольный словарь (англ ↔ рус)" );

        while ( true )
        {
            ConsoleHelper.PrintInfo( "\nВыберите действие:" );
            Console.WriteLine( "1) Перевод слов    (Enter)" );
            Console.WriteLine( "2) Добавление слов (+)" );
            Console.WriteLine( "3) Выход           (Esc)" );
            var key = Console.ReadKey( true ).Key;

            switch ( key )
            {
                case ConsoleKey.Enter:
                case ConsoleKey.D1:
                    TranslateWord( manager );
                    break;
                case ConsoleKey.Add:
                case ConsoleKey.OemPlus:
                case ConsoleKey.D2:
                    AddWord( manager );
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.D3:
                    return;
                default:
                    ConsoleHelper.PrintError( "Неверный ввод" );
                    break;
            }
        }
    }

    static void AddWord( DictionaryManager manager )
    {
        Console.Write( "\nВведите слово на английском: " );
        string? eng = ConsoleHelper.ReadString();

        Console.Write( "Введите перевод на русский: " );
        string? ru = ConsoleHelper.ReadString();

        manager.Add( eng, ru );

        ConsoleHelper.PrintSuccess( "Слово успешно добавлено!" );
    }

    static void TranslateWord( DictionaryManager manager )
    {
        Console.Write( "\nВведите слово для перевода: " );
        string? word = ConsoleHelper.ReadString();

        var translations = manager.Get( word );

        if ( translations.Count == 0 )
        {
            ConsoleHelper.PrintWarning( "Перевод не найден." );
        }
        else
        {
            ConsoleHelper.PrintSuccess( $"\nНайденные переводы слова {word}:" );
            foreach ( var translation in translations )
            {
                Console.WriteLine( $"  {translation}" );
            }
        }
    }
}
