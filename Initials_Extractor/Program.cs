namespace Initials_Extractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] AUTORIZED_CHARACTERS = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'À', 'Â', 'Ä', 'Ç', 'É', 'È', 'Ê', 'Ë', 'Î', 'Ï', 'Ô', 'Ö', 'Ù', 'Û', 'Ü', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', '-', '\'' };
            string initials = "";

            while (initials == "")
            {
                bool whiteSpaceAndApostrophe = false;
                bool hyphen = false;
                bool lettersAndDigits = false;

                Console.WriteLine("Enter your first name, followed by your last name:");

                string originalText = Console.ReadLine().Trim('-', '\'', ' ').ToUpper();

                for (int position = 0; position < originalText.Length; position++)
                {
                    char character = originalText[position];

                    if (AUTORIZED_CHARACTERS.Contains(character))
                    {
                        if (character != ' ' && character != '-' && character != '\'')
                        {
                            if (!lettersAndDigits)
                            {
                                initials += character;

                                if (whiteSpaceAndApostrophe || hyphen)
                                {
                                    whiteSpaceAndApostrophe = false;
                                    hyphen = false;
                                }

                                lettersAndDigits = true;
                            }
                        }

                        else if (character == ' ' || character == '\'')
                        {
                            if (!whiteSpaceAndApostrophe)
                            {
                                if (lettersAndDigits)
                                {
                                    lettersAndDigits = false;
                                }

                                whiteSpaceAndApostrophe = true;
                            }
                        }

                        else
                        {
                            if (!hyphen)
                            {
                                initials += character;

                                if (lettersAndDigits)
                                {
                                    lettersAndDigits = false;
                                }

                                hyphen = true;
                            }
                        }
                    }

                    else
                    {
                        whiteSpaceAndApostrophe = false;
                        hyphen = false;
                        lettersAndDigits = false;
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine($"Your initials are:\n{initials}");
        }
    }
}