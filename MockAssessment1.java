import java.util.Stack;

class Solution {
    // Given the root of a binary search tree and the lowest and highest boundaries as low and high, trim the tree so that all its elements lies in [low, high]. Trimming the tree should not change the relative structure of the elements that will remain in the tree (i.e., any node's descendant should remain a descendant). It can be proven that there is a unique answer.

    // Return the root of the trimmed binary search tree. Note that the root may change depending on the given bounds.

 

    // Example 1:


    // Input: root = [1,0,2], low = 1, high = 2
    // Output: [1,null,2]
    // Example 2:


    // Input: root = [3,0,4,null,2,null,null,1], low = 1, high = 3
    // Output: [3,2,null,1]
    

    // Constraints:

    // The number of nodes in the tree is in the range [1, 104].
    // 0 <= Node.val <= 104
    // The value of each node in the tree is unique.
    // root is guaranteed to be a valid binary search tree.
    // 0 <= low <= high <= 104


    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     int val;
     *     TreeNode left;
     *     TreeNode right;
     *     TreeNode() {}
     *     TreeNode(int val) { this.val = val; }
     *     TreeNode(int val, TreeNode left, TreeNode right) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public TreeNode trimBST(TreeNode root, int low, int high) {
        if (root == null) {
            return null;
        }
        if (root.val < low) {
            return trimBST(root.right, low, high);
        }
        if (root.val > high) {
            return trimBST(root.left, low, high);
        }
        root.left = trimBST(root.left, low, high);
        root.right = trimBST(root.right, low, high);
        return root;
    }


    // You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

    // You may assume the two numbers do not contain any leading zero, except the number 0 itself.

    

    // Example 1:


    // Input: l1 = [7,2,4,3], l2 = [5,6,4]
    // Output: [7,8,0,7]
    // Example 2:

    // Input: l1 = [2,4,3], l2 = [5,6,4]
    // Output: [8,0,7]
    // Example 3:

    // Input: l1 = [0], l2 = [0]
    // Output: [0]
    

    // Constraints:

    // The number of nodes in each linked list is in the range [1, 100].
    // 0 <= Node.val <= 9
    // It is guaranteed that the list represents a number that does not have leading zeros.


    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     int val;
     *     ListNode next;
     *     ListNode() {}
     *     ListNode(int val) { this.val = val; }
     *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
     * }
     */
    
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        Stack<Integer> s1 = new Stack<Integer>();
        Stack<Integer> s2 = new Stack<Integer>();
        while (l1 != null) {
            s1.push(l1.val);
            l1 = l1.next;
        }
        while (l2 != null) {
            s2.push(l2.val);
            l2 = l2.next;
        }
        int sum = 0;
        ListNode list = new ListNode(0);
        while (!s1.empty() || !s2.empty()) {
            if (!s1.empty()) {
                sum += s1.pop();
            }
            if (!s2.empty()) {
                sum += s2.pop();
            }
            if (sum > 9) {
                list.val = sum - 10;
                sum = 1;
            } else {
                list.val = sum;
                sum = 0;
            }
            ListNode head = new ListNode(sum);
            head.next = list;
            list = head;
        }
        return list.val == 0 ? list.next : list; 
    }
}