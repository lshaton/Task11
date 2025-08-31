using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        PermutationsTest.RunTests();
    }
}

class Permutations
{
    public static List<string> SinglePermutations(string s)
    {
        // Handle edge case: empty or null string
        if (string.IsNullOrEmpty(s))
            return new List<string>();
        
        // Use HashSet to automatically handle duplicates
        HashSet<string> result = new HashSet<string>();
        char[] chars = s.ToCharArray();
        
        // Generate all permutations using recursive backtracking
        GeneratePermutations(chars, 0, result);
        
        // Convert HashSet to List and return
        return new List<string>(result);
    }
    
    private static void GeneratePermutations(char[] chars, int start, HashSet<string> result)
    {
        // Base case: if we've reached the end, add the current permutation
        if (start == chars.Length)
        {
            result.Add(new string(chars));
            return;
        }
        
        // Try placing each character at the current position
        for (int i = start; i < chars.Length; i++)
        {
            // Swap current character with the character at start position
            Swap(chars, start, i);
            
            // Recursively generate permutations for the remaining positions
            GeneratePermutations(chars, start + 1, result);
            
            // Backtrack: restore the original arrangement
            Swap(chars, start, i);
        }
    }
    
    private static void Swap(char[] chars, int i, int j)
    {
        char temp = chars[i];
        chars[i] = chars[j];
        chars[j] = temp;
    }
}

class PermutationsTest
{
    public static void RunTests()
    {
        Console.WriteLine("Running Permutations Tests...\n");
        
        // Test all cases
        TestSingleCharacter();
        TestTwoCharacters();
        TestThreeCharacters();
        TestAllIdentical();
        TestPartialDuplicates();
        TestComplexDuplicates();
        TestEmptyString();
        
        Console.WriteLine("All tests completed!");
    }
    
    private static void TestSingleCharacter()
    {
        Console.WriteLine("Testing single character 'a':");
        var result = Permutations.SinglePermutations("a");
        var expected = new List<string> { "a" };
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static void TestTwoCharacters()
    {
        Console.WriteLine("Testing two characters 'ab':");
        var result = Permutations.SinglePermutations("ab");
        var expected = new List<string> { "ab", "ba" };
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static void TestThreeCharacters()
    {
        Console.WriteLine("Testing three characters 'abc':");
        var result = Permutations.SinglePermutations("abc");
        var expected = new List<string> { "abc", "acb", "bac", "bca", "cab", "cba" };
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static void TestAllIdentical()
    {
        Console.WriteLine("Testing all identical 'aaa':");
        var result = Permutations.SinglePermutations("aaa");
        var expected = new List<string> { "aaa" };
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static void TestPartialDuplicates()
    {
        Console.WriteLine("Testing partial duplicates 'aa':");
        var result = Permutations.SinglePermutations("aa");
        var expected = new List<string> { "aa" };
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static void TestComplexDuplicates()
    {
        Console.WriteLine("Testing complex duplicates 'aabb':");
        var result = Permutations.SinglePermutations("aabb");
        var expected = new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" };
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static void TestEmptyString()
    {
        Console.WriteLine("Testing empty string:");
        var result = Permutations.SinglePermutations("");
        var expected = new List<string>();
        
        Console.WriteLine($"Result: [{string.Join(", ", result.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Expected: [{string.Join(", ", expected.Select(s => $"'{s}'"))}]");
        Console.WriteLine($"Count: {result.Count} (expected: {expected.Count})");
        Console.WriteLine($"Test Passed: {AreListsEqual(result, expected)}\n");
    }
    
    private static bool AreListsEqual(List<string> list1, List<string> list2)
    {
        if (list1.Count != list2.Count)
            return false;
        
        var set1 = new HashSet<string>(list1);
        var set2 = new HashSet<string>(list2);
        
        return set1.SetEquals(set2);
    }
}
