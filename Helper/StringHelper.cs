

namespace SBase.Helper
{
    public class StringHelper
    {
        /// <summary>
        /// Counts the number word by the given text.
        /// </summary>
        /// <param name="text">The text input.</param>
        /// <returns>The number of the word in the text.</returns>
        public static int CountWords(string text)
        {
            int count = 0;

            if ( !string.IsNullOrEmpty(text) )
            {
                
                int size = text.Length;

                bool notCounted = true;

                for( int i = 0; i < size; i++ )
                {
                    char c = text[i];
                    if (c != Characters.Space && c != Characters.Tab && c != Characters.BreakLine )
                    {
                        if (notCounted)
                        {
                            count++;
                            notCounted = false;
                        }
                    }
                    else
                    {
                        notCounted = true;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Random the string with the size.
        /// </summary>
        /// <param name="size">The size of the string random. By default, the value is 6.</param>
        /// <returns></returns>
        public static string Random(int size = 6)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            var stringChars = new char[size];

            // Loop through the size of the string
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        /// <summary>
        /// Counts the number of the sentence by the given text.
        /// </summary>
        /// <param name="text">The text input.</param>
        /// <returns></returns>
        public static int CountSentences(string text)
        {
            int count = 0;

            // Check if the string is null or empty
            if (string.IsNullOrEmpty(text))
                return count;

            // Define delimiters for sentences
            char[] delimiters = { Characters.Dot };

            // Split the text into sentences using delimiters
            string[] sentences = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Count the number of sentences
            count = sentences.Length;

            return count;
        }
    }

    /// <summary>
    /// This class is provider all character common.
    /// </summary>
    public static class Characters
    {
        public const char Dot = '.';

        public const char Comma = ',';

        public const char Slash = '/';

        public const char Space = ' ';

        public const char BreakLine = '\n';

        public const char Tab = '\t';

        public const string QuestionMark = "?";
    }
}
