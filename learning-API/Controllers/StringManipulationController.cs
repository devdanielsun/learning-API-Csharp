using learning_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace learning_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringManipulationController : Controller
    {
        [HttpGet]
        public Dictionary<string, object> Get([FromQuery] string input)
        {
            var result = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(input))
            {
                result.Add("Input string is empty or null", null);
                return result;
            }

            var reversed = ReverseString(input);
            var uppercased = input.ToUpper();
            var lowercased = input.ToLower();
            var words = SplitIntoWords(input);
            var chars = SplitIntoChars(input);
            var length = input.Length;
            var substring = GetSubstring(input, 0, Math.Min(5, input.Length)); // First 5 characters
            var replaced = ReplaceCharacters(input, 'a', 'o'); // Example: replace 'a' with 'o'
            var trimmed = input.Trim();
            var isPalindrome = IsPalindrome(input);
            var vowelCount = CountVowels(input);
            var consonantCount = CountConsonants(input);
            var removedVowels = RemoveVowels(input);
            var removedConsonants = RemoveConsonants(input);
            var areCharactersAreDigits = AreCharactersAreDigits(input);
            var areCharactersAreLetters = AreCharactersAreLetters(input);
            var areCharactersAreUppercase = AreCharactersAreUppercase(input);
            var areCharactersAreLowercase = AreCharactersAreLowercase(input);
            var reverseSentence = ReverseSentence(input);

            result.Add("Original", input);
            result.Add("Reversed", reversed);
            result.Add("Uppercased", uppercased);
            result.Add("Lowercased", lowercased);
            result.Add("Words", words);
            result.Add("Characters", chars);
            result.Add("Length", length);
            result.Add("Substring (first 5 chars)", substring);
            result.Add("Replaced 'a' with 'o'", replaced);
            result.Add("Trimmed", trimmed);
            result.Add("Is Palindrome", isPalindrome);
            result.Add("Vowel Count", vowelCount);
            result.Add("Consonant Count", consonantCount);
            result.Add("Removed Vowels", removedVowels);
            result.Add("Removed Consonants", removedConsonants);
            result.Add("Check if All Charachters are Digits", areCharactersAreDigits);
            result.Add("Check if All Charachters are Letters", areCharactersAreLetters);
            result.Add("Check if All Charachters are Uppercase", areCharactersAreUppercase);
            result.Add("Check if All Charachters are Lowercase", areCharactersAreLowercase);
            result.Add("Reverse sentence", reverseSentence);

            return result;
        }

        private string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }

        private string[] SplitIntoWords(string input)
        {
            return input.Split(' ');
        }

        private char[] SplitIntoChars(string input)
        {
            return input.ToCharArray();
        }

        private string GetSubstring(string input, int startIndex, int length)
        {
            return input.Substring(startIndex, length);
        }

        private string ReplaceCharacters(string input, char oldChar, char newChar)
        {
            return input.Replace(oldChar, newChar);
        }

        private bool IsPalindrome(string input)
        {
            var reversed = ReverseString(input);
            return string.Equals(input, reversed, StringComparison.OrdinalIgnoreCase);
        }

        private int CountVowels(string input)
        {
            return input.Count(c => "aeiouAEIOU".Contains(c));
        }

        private int CountConsonants(string input)
        {
            return input.Count(c => "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".Contains(c));
        }

        private string RemoveVowels(string input)
        {
            return new string(input.Where(c => !"aeiouAEIOU".Contains(c)).ToArray());
        }

        private string RemoveConsonants(string input)
        {
            return new string(input.Where(c => !"bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".Contains(c)).ToArray());
        }

        private bool AreCharactersAreDigits(string input)
        { 
            return input.All(char.IsDigit);
        }

        private bool AreCharactersAreLetters(string input)
        {
            return input.All(char.IsLetter);
        }

        private bool AreCharactersAreUppercase(string input)
        {
            return input.All(char.IsUpper);
        }

        private bool AreCharactersAreLowercase(string input)
        {
            return input.All(char.IsLower);
        }

        private string ReverseSentence(string input)
        {
            return string.Join(' ', input.Split(' ').Reverse());
        }
    }
}