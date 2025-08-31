using System;
using System.Collections.Generic;
using System.Linq;

class PermutationsTest
{
    public static void Main(string[] args)
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