using System;
using System.Collections.Generic;

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