// You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.

// Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

 

// Example 1:

// Input: flowerbed = [1,0,0,0,1], n = 1
// Output: true
// Example 2:

// Input: flowerbed = [1,0,0,0,1], n = 2
// Output: false
 

// Constraints:

// 1 <= flowerbed.length <= 2 * 104
// flowerbed[i] is 0 or 1.
// There are no two adjacent flowers in flowerbed.
// 0 <= n <= flowerbed.length

public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
      if (n == 0) {
        return true;
      }
      if (flowerbed.Length < 2) {
        return flowerbed[0] == 0;
      }
      int availableSpaces = 0;
      if (flowerbed[0] == 0 && flowerbed[1] == 0) {
        flowerbed[0] = 1;
        availableSpaces++;
      }
      if (flowerbed[flowerbed.Length - 1] == 0 && flowerbed[flowerbed.Length - 2] == 0) {
        flowerbed[flowerbed.Length - 1] = 1;
        availableSpaces++;
      }
      for (int i = 1; i < flowerbed.Length - 1; i++) {
        if (flowerbed[i] == 0 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0) {
          flowerbed[i] = 1;
          availableSpaces++;
        }
      }
      return n <= availableSpaces;
    }
}

// You are given a string s that consists of lower case English letters and brackets.

// Reverse the strings in each pair of matching parentheses, starting from the innermost one.

// Your result should not contain any brackets.

 

// Example 1:

// Input: s = "(abcd)"
// Output: "dcba"
// Example 2:

// Input: s = "(u(love)i)"
// Output: "iloveu"
// Explanation: The substring "love" is reversed first, then the whole string is reversed.
// Example 3:

// Input: s = "(ed(et(oc))el)"
// Output: "leetcode"
// Explanation: First, we reverse the substring "oc", then "etco", and finally, the whole string.
 

// Constraints:

// 1 <= s.length <= 2000
// s only contains lower case English characters and parentheses.
// It is guaranteed that all parentheses are balanced.

public class Solution {
  public string ReverseParentheses(string s) {
    Stack<StringBuilder> st = new Stack<StringBuilder>();
    StringBuilder sb = new StringBuilder();
    foreach (char c in s.ToCharArray()) {
      if (c == '(') {
        st.Push(sb);
        sb = new StringBuilder();
      } else if (c == ')') {
        string str = ReverseStringBuilder(sb).ToString();
        sb = st.Pop();
        sb.Append(str);
      } else {
        sb.Append(c);
      }
    }
    return sb.ToString();
  }

  private StringBuilder ReverseStringBuilder(StringBuilder sb) {
    int length = sb.Length;
    for (int i = 0; i < length / 2; i++) {
      char temp = sb[i];
      sb[i] = sb[length - i - 1];
      sb[length - i - 1] = temp;
    }
    return sb;
  }
}