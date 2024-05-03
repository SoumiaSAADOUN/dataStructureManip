// the time complexity of this solution is O(n), the space complexity is O(n) 
// the structure that represents a node of the tree
class ListNode {
  constructor(val) {
    this.val = val;
    this.left = null;
    this.right = null;
  }
}

// the queue that is used to manipulate the tree
class Dequeue {
  constructor() {
    this.queue = [];
  }
  // check if the queue in empty
  isEmpty() {
    return this.queue.length === 0;
  }
  // push data to the queue
  Enqueue(val) {
    this.queue.push(val);
  }
  // pop data from the queue
  Dequeue() {
    return this.queue.shift();
  }
}

function BinaryTreeBftUsingQueue(head) {
  var dequeue = new Dequeue();
  dequeue.Enqueue(head); // enqueue the head
  while (!dequeue.isEmpty()) {
    //pop the tail
    var current = dequeue.Dequeue();
    console.log(current.val);
    // check if it has children, so we add them to the queue
    if (current.left != null) dequeue.Enqueue(current.left);
    if (current.right != null) dequeue.Enqueue(current.right);
  }
}

// Create a binary tree and enter the nodes
const root = new ListNode(1);
root.left = new ListNode(2);
root.right = new ListNode(3);
root.left.left = new ListNode(4);
root.left.right = new ListNode(5);
// Print the level order traversal of the binary tree
console.log("Level order traversal of binary tree is - ");
BinaryTreeBftUsingQueue(root);
